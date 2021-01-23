    using System;
    using System.IO;
    
    class App
    {
        public static void Main()
        {
            string searchPath = @"c:\";
            string searchPattern = "list.*";
    
            DirectoryInfo di = new DirectoryInfo(searchPath);
            FileInfo[] files = di.GetFiles(searchPattern, SearchOption.AllDirectories);
    
            foreach (FileInfo file in files)
                Console.WriteLine(file.FullName);
    
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
