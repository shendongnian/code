    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"^(?:40[0-9][0-5]|[1-3][0-9]{3}|[0-9]{1,3}),(?:40[0-9][0-5]|[1-3][0-9]{3}|[0-9]{1,3}),(?:40[0-9][0-5]|[1-3][0-9]{3}|[0-9]{1,3}),(?:40[0-9][0-5]|[1-3][0-9]{3}|[0-9]{1,3})$";
            string input = @"1200,2500,6500,90
    1200,2500,6500,90
    1200,2500,4095,90
    0,0,0,0
    4095,4095,4095,4095
    
    ";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
