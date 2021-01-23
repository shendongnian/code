    static void Main(string[] args)
        {
            string path = @"C:\TestFile.xml";
            string input = File.ReadAllText(path);
            
            string pattern = @"<(.*)>(.*)</\1>";
            
            foreach (Match m in Regex.Matches(input, pattern))
            {
                System.Console.WriteLine(m.Groups[2].Value);
                System.Console.WriteLine("\n");
            }
        }
