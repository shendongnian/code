    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication103
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = 
                            "VER A 150 VER A 56 VER A 131\n" +
                            "VER Z 208 VER Z 209 VER Z 250\n" +
                            "VER W 300 VER W 200 VER W 124\n"
                        ;
                StringReader reader = new StringReader(input);
                string line = "";
                string pattern = @"[^\d]+\d+";
                while ((line = reader.ReadLine()) != null)
                {
                    MatchCollection matches = Regex.Matches(line, pattern);
                    string[][] splitData = matches.Cast<Match>()
                        .Select(x => x.Value.Trim()
                        .Split(new char[] { ' ' }).ToArray())
                        .ToArray();
                    var result = splitData
                        .Select(x => new { letter = x.Skip(1).First(), number = int.Parse(x.Last()) })
                        .OrderByDescending(x => x.number)
                        .FirstOrDefault();
                    Console.WriteLine("letter = '{0}', number =  '{1}'", result.letter, result.number);
                }
                Console.ReadLine();
            }
        }
     
    }
