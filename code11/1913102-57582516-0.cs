    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"^Name:\s*([^,]*?)\s*,\s*(.*\s)?(\S*)$";
            string input = @"Name: JAMES, 1ST LT LABRON
    Name: KNOTS, PFC DON
    Name: BUILDER , BOB
    Name: JAMES, 1ST LT O'CONNOR
    Name: KNOTS, PFC Renée
    Name: BUILDER , Chloé";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
