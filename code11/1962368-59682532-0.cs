    using System.IO;
    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main(string[] args)
        {
            string root = @"D:\";
            string[] subdirectories = Directory.GetDirectories(root);
    		List<string> listDirs = new List<string>();
    
            foreach (string subdir in subdirectories)
            {
                LoadSubDirs(subdir, listDirs);
            }
    
        }
        private static void LoadSubDirs(string dir, List<string> listDirs)
        {
            Console.WriteLine(dir);
    		listDirs.Add(dir);
    
            try
            {
                string[] subdirectories = Directory.GetDirectories(dir);
    
                foreach (string subdir in subdirectories)
                {
                    try
                    {
                        LoadSubDirs(subdir, listDirs);
                    }
                    catch { }
                }
            }
        }
    }
