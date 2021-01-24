    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication118
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "In a given health plan your Plan Name: Medical and Plan Type: PPO whose effective date: 2019-01-01 and coverage value $100 and $200";
                string pattern = @"(?'key'\w+):\s+(?'value'[-\d\w]+)|(?'key'\w+)\s+(?'value'\$\d+\s+and\s+\$\d+)";
                MatchCollection matches = Regex.Matches(input, pattern);
                Dictionary<string, string> dict = matches.Cast<Match>()
                    .GroupBy(x => x.Groups["key"].Value, y => y.Groups["value"].Value)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                foreach (Match match in matches)
                {
                    Console.WriteLine("Key : '{0}', Value : '{1}'", match.Groups["key"].Value, match.Groups["value"].Value);
                }
                Console.ReadLine();
            }
        }
    }
