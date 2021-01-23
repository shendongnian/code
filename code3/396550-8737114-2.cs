    static void Main(string[] args)
    {
         StreamReader oReader;
         if (File.Exists(@"C:\TextFile.txt"))
         {
              Console.WriteLine("Enter a word to search");
              string cSearforSomething = Console.ReadLine().Trim();
              oReader = new StreamReader(@"C:\TextFile.txt");
              string cColl = oReader.ReadToEnd();
              string cCriteria = @"\b"+cSearforSomething+@"\b";
              System.Text.RegularExpressions.Regex oRegex = new System.Text.RegularExpressions.Regex(cCriteria,RegexOptions.IgnoreCase);
    
              int count = oRegex.Matches(cColl).Count;
              Console.WriteLine(count.ToString());
         }
         Console.ReadLine();
    }
