    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"[)(]|\d+\.\d+|\w+";
            string input = @"(0.2 furry
              (0.81 fast
                (0.3)
                (0.2)
              )
              (0.1 fishy
                (0.3 freshwater
                  (0.01)
                  (0.01)
                )
                (0.1)
              )
            )";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
