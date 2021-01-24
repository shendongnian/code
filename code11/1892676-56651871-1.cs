    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(?=dfm\s+|adx\s+)(?:dfm\s+([A-Z0-9]+)|adx\s+([0-9]+))|(?=dfm)dfm([0-9]+)|[A-Za-z0-9]+";
            string input = @"dfm HSBC12323
    HSBC12323
    dfm123213
    adx 212321
    usa1237";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
