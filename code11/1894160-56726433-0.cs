    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"^[0-9]{4}$";
            string input = @"6319
    4/22/2017 6:28:17 PM
    2016 MALAWI SCHOOL CERTIFICATE OF EDUCATION EXAMINATIONS
    2016";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
