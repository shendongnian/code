    using System;
    using System.IO;
    using System.Text;
    
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"C:\myfile.txt", Encoding.GetEncoding(1252)))
            {
                // read the file with the reader object.
            }
    
        }
    }
