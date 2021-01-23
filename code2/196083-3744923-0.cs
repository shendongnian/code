    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main()
        {
            Match("$25/$2.05");
            Match("$2.05/$2.05");
            Match("$25.00/$22.05");
            Match("$25/$10");
            Match("x/$10");
            Match("$10/x");
            Match("$10$20");
        }
        
        private static readonly Regex Pattern = new Regex
            (@"^\$(\d+(?:\.\d{2})?)/\$(\d+(?:\.\d{2})?)$");
        
        static void Match(string text)
        {
            Match match = Pattern.Match(text);
            if (!match.Success) {
                Console.WriteLine("{0}: Match failed", text);
                return;
            }
            Console.WriteLine("{0}: Matched! First: {1} Second: {2}",
                              text, match.Groups[1], match.Groups[2]);
        }
    }
