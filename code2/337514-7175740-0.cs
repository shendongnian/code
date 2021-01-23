    using System;
    using System.IO;
    
    class Test
    {
        static void Main()
        {
            string text = "line1\r\nline2";
            
            using (TextReader reader = new StringReader(text))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
