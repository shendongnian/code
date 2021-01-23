    using System;
    using System.IO;
    
    class Test
    {
        static void Main()
        {
            string x;
            using (new MemoryStream())
            {
                x = "hello";
            }
            Console.WriteLine(x);
        }
    }
