    using System;
    using System.IO;
    
    class Program
    {
        static void Main()
        {
            string path = "C:\\images\\universe.jpg";
            // Get directory name.
            string result = Path.GetDirectoryName(path);
    
            Console.WriteLine("PATH:      {0}", path);
            Console.WriteLine("DIRECTORY: {0}", result);
        }
    }
