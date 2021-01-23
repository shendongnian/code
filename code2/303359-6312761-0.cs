    using System;
    using System.Text.RegularExpressions;
    namespace SO6312611
    {
        class Program
        {
            static void Main()
            {
                string input = "id=resultsStats>anything<nobr>";
                Regex r = new Regex("id=resultsStats>(?<data>[^<]*)<nobr>");
                Match m = r.Match(input);
                Console.WriteLine("Matched: >{0}<", m.Groups["data"]);
            }
        }
    }
