    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"^(?:(?:40\d[0-5]|[1-3]\d{3}|[1-9]\d{2}|[1-9]\d|\d),){3}(?:40\d[0-5]|[1-3]\d{3}|[1-9]\d{2}|[1-9]\d|\d)$";
            string input = @"1200,2500,6500,90
                1200,2500,6500,90
                1200,2500,4095,90
                0,0,0,0
                999,1,0,99
                000,000,000,000
                4095,4095,4095,4095
    
                ";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
