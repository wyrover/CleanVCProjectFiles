using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CleanVCProjectFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("You must specify the directory path to clean");
                return;
            }

            string path = args[0];
            string[] extensions = { ".pdb", ".ncb", ".obj", ".exe", "*.dll", ".ocx", ".user", ".bak", ".suo" };

            foreach (string file in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                .Where(s => extensions.Any(ext => ext == Path.GetExtension(s).ToLower())))
            {
                try
                {
                    File.Delete(file);
                    Console.WriteLine("An file has been deleted: " + file);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("An error ocurred: " + ex.Message);
                    continue;	
                }
            }
        }
    }
}