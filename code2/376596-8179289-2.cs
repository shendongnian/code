    using System;
    using System.IO;
    using System.Text;
    
    class Test
    {
        static void Main()
        {
            Encoding encoding = Encoding.GetEncoding(28591);
            StringBuilder output = new StringBuilder();
            using (TextReader reader = new StreamReader("file.html", encoding))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    output.AppendLine("Read line: " + line);
                }
            }
            using (StreamWriter writer = new StreamWriter("output.html", false))
            {
                writer.Write(output);
            }
        }
    }
