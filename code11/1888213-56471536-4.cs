    using System;
    using System.Text.RegularExpressions;
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(?=.*\bcat\b|.*\bdog\b).*";
            string input = @"cat
    dog
    catdog
    Anything we wish before cat then anything we wish afterwards
    Anything we wish before dog then anything we wish afterwards
    Anything we wish before catdog then anything we wish afterwards";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
