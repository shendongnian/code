    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(SI)|[""](;)[A-Z]|[0-9](;)[""]|[)](;)[""]";
            string input = @"=SI(renamed=""SI"";SI(f1<f4;""SI("";""nok"");""1;2"")";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
