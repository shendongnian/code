    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"^(.*?)\s*(\(\s*\d+\)\s*)?$";
            string input = @"Test
    Test (1)
    Test (1) (2)
    Test (1) (2) (3)
    Test (1) (2)    (3) (4) 
    ";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
