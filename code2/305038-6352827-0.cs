    using System;
    using System.IO;
    using System.Text;
    
    class Test
    {
    
        public static void Main()
        {
            string path = @"c:\temp\MyTest.txt";
    
            // Delete the file if it exists.
            if (File.Exists(path))
            {
                File.Delete(path);
            }
    
            //Create the file.
            DateTime start = DateTime.Now;
            using (FileStream fs = File.Create(path))
            {
                fs.SetLength(1024*1024*1024);
            }
            TimeSpan elapsed = DateTime.Now - start;
            Console.WriteLine(@"FileStream SetLength took: {0} to complete", elapsed.ToString() );
        }
    }
