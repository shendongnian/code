    using System;
    using System.IO;
    class Test
    {
        public static void Main()
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            using (StreamReader sr = new StreamReader(@"d:\temp\TestFile.txt"))
            {
                string line = sr.ReadLine();
                string[] words = line.Split(delimiterChars);
                if (words[0] == "00")
                {
                    Console.WriteLine($"Found it, yay!  words[0]={words[0]}, words[1]={words[1]}");
                }
            }
        }
    }
