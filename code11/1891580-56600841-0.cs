    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication114
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "CREATE TABLE Tablex(" +
                      " column1 INT," +
                      " column2 TEXT," +
                      " column3 INT," +
                      " column4 INT," +
                   ")";
                string pattern1 = @"CREATE TABLE Tablex\((?'columns'[^)]+)\)";
                Match columnsMatch = Regex.Match(input, pattern1);
                string columns = columnsMatch.Groups["columns"].Value.Trim();
                string pattern = @"\s*(?'key'[^\s]+)\s+(?'value'\w+)[,$]";
                MatchCollection matches = Regex.Matches(columns, pattern);
                foreach(Match match in matches.Cast<Match>())
                {
                    Console.WriteLine("Key : '{0}', Value : '{1}'", match.Groups["key"].Value, match.Groups["value"].Value);
                }
                Console.ReadLine();
            }
        }
    }
