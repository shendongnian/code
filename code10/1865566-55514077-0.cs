    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication107
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "aSd2&5s@1";
                string pattern1 = @"[a-zA-z@&]+\d+";
                MatchCollection matches = Regex.Matches(input, pattern1);
                string output = "";
                foreach(Match match in matches.Cast<Match>().ToList())
                {
                    string pattern2 = @"(?'string'[^\d]+)(?'number'\d+)";
                    Match match2 = Regex.Match(match.Value, pattern2);
                    int number = int.Parse(match2.Groups["number"].Value);
                    string str = match2.Groups["string"].Value;
                    
                    output += string.Join("",Enumerable.Repeat(str.ToUpper(), number));
                }
                Console.WriteLine(output);
                Console.ReadLine();
     
            }
        }
     
     
    }
