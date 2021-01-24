    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"^www\.[A-Za-z_]+\.com";
            string input = @"www.google.com
    www.youwebsite.com
    
    http://www.google.com
    https://www.google.com
    google.com
    www.google";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
