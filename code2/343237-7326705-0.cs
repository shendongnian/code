    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main(string[] args)
        {
            string x = "X=113.3413475 Y=18.2054775";
            Regex regex = new Regex(@"[0-9]+\.[0-9]*|\.[0-9]+|[0-9]+");
            var matches = regex.Matches(x);
            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
