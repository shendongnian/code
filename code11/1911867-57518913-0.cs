    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"^(?:-?\d{1,3},?)?(?:\d{3},?)*\.[0-9]{1,2}(?:-(?:\d{1,3},?)?(?:\d{3},?)*\.[0-9]{1,2})?$";
            string input = @"1,000,000.0
    -1,000,000.0
    100,000,000.0
    -1,000,000,000,000.0
    1.00-2.00
    1.00
    
    1
    11
    123
    0
    
    .00,00
    -5,000000";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
