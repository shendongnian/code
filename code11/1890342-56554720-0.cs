    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"\/[A-Za-z]+\/specific_word\/[0-9]+";
            string input = @"/anyword/specific_word/012345
    /anyword1/specific_word/012345
    /anyword/specific_word_0/012345";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
