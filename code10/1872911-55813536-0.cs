        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("TestFile.txt");
            String searched = "World";
            Regex reg = new Regex(@"\b\w*" + searched + @"\w*\b");
            
            string text = sr.ReadToEnd();
            int lastIndex = 0;
            MatchCollection matches = reg.Matches(text);
            
            foreach(Match m in matches)
            {
                Console.Write(text.Substring(lastIndex, m.Index - lastIndex));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(m.Value);
                Console.ResetColor();
                lastIndex = m.Index + m.Length;
            }
            if(lastIndex < text.Length)
                Console.Write(text.Substring(lastIndex, text.Length - lastIndex));
            
            Console.ReadLine();
        }
