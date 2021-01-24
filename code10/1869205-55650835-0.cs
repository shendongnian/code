    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication108
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "I wandered lonely as a cow";
                string pattern = @"(?'word'\w+)\s*";
                string[] words = Regex.Matches(input, pattern).Cast<Match>().Select(x => x.Groups["word"].Value).ToArray();
                var results = words
                    .Select(x => new { word = x, characters = x.ToCharArray().Select((y, i) => new { ch = y, index = i }).GroupBy(y => y.ch).Select(y => y.First()).ToList() }).ToList();
            }
        }
     
    }
