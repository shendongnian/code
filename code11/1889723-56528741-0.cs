    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"type:(\s+)?'(\s+)?(.+?)(\s+)?',";
            string input = @"type:' EXAMPLE ',
    type: ' EXAMPLE ',
    type:    '   EXAMPLE    ',
    type:    '   Any other EXAMPLE we might have   ',";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
