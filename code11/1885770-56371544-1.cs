    using System;
    using System.Text.RegularExpressions;
    public class Example
    {
        public static void Main()
        {
            string pattern = @"\(([0-9\-\.]+)\)";
            string input = @"Alarm Level 1 (D1) [Low (15.7)]
    Alarm Level 2 [High (-12.7)]";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
