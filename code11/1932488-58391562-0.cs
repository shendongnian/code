    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "7 \"Fault\" 6 \"Reserved\" 2 \"Running\" 1 \"Cranking\" 0 \"Stop\"";
                string pattern = "(?'key'\\d+)\\s+\"(?'value'[^\"]+)\"";
                MatchCollection matches = Regex.Matches(input, pattern);
                foreach (Match match in matches.Cast<Match>())
                {
                    Console.WriteLine("{0} {1}", match.Groups["key"].Value, match.Groups["value"].Value); 
                }
                Console.ReadLine();
            }
        }
    }
