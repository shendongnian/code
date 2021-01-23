    using System;
    using System.IO;
    
    class Test
    {
        static void Main()
        {
            DateTime today = DateTime.Today;
            foreach (FileInfo file in new DirectoryInfo(".").GetFiles())
            {
                if (file.LastWriteTime >= today)
                {
                    Console.WriteLine(file.Name);
                }
            }
        }
    }
