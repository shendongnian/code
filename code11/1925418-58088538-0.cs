    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"Model\:\s([\w\d]*).*Serial\:\s([\w\d]*).*";
            string input = @"Room: 501, User: John, Model: XPR500   Serial: JK0192, Condition: Good";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
