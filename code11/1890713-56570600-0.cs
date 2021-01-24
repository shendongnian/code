    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"\b([0-9]{5})\b(?:\s|$)";
            string input = @"4034 Wells Branch, San Francisco CA 34123
    4034 Wells Branch, San Francisco CA 34123-
    4034 Wells Branch, San Francisco CA 34123-1234
    4034 Wells Branch, San Francisco CA 341231234";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
