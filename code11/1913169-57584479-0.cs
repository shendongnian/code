    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"^(?=.*\bgermany\b).*$";
            string input = @"some data germany some other data
    some data Germany some other data
    some data GERMANY some other data
    some data France some other data
    some data UK some other data";
            RegexOptions options = RegexOptions.Multiline | RegexOptions.IgnoreCase;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
