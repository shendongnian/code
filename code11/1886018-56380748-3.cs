    using System;
    using System.Text.RegularExpressions;
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(ISS\/\d{4}-\d{2}-\d{2})[\s\S]*";
            string input = @"ISS/2018-03-02 
    ISS/2005-03-09
    ISS/2018-03-02 
    ISS/2005-03-09
    ISS/2018-03-02 
    ISS/2005-03-09";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
