    using System;
    using System.Text.RegularExpressions;
    namespace consoleapp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string text = "john monday 500 sara monday 600 sunny monday 1200 john monday 500 sara monday 300 sunny monday 2200 john monday 400 sara monday 100 sunny monday 500 john monday 520 sara monday 600 sunny monday 10 john monday 990 sara monday 850 sunny monday 1000 john monday 300 sara monday 200 sunny monday";
                var saraPattern = new Regex(@"sara\s\w+\s\d+");
                var numberPattern = new Regex(@"[\d\.\,]+");
                var matches = saraPattern.Matches(text);
                foreach (Match match in matches)
                {
                    var numbermatch = numberPattern.Match(match.Value);
                    var number = float.Parse(numbermatch.Value);
                    Console.WriteLine(number);
                }
                Console.ReadKey();
            }
        }
    }
