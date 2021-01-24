    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Globalization;
    namespace ConsoleApplication125
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                string pattern1 = @"(?'time'.*):GMT: subject=(?'subject'[^,]+), message=\{(?'message'[^}]+)";
                StreamReader reader = new StreamReader(FILENAME);
                string line = "";
                while((line = reader.ReadLine()) != null)
                {
                    Match match = Regex.Match(line, pattern1);
                    DateTime time = DateTime.ParseExact(match.Groups["time"].Value, "yyyy:MM:dd:HH:mm:ss", CultureInfo.InvariantCulture);
                    string subject = match.Groups["subject"].Value;
                    string message = match.Groups["message"].Value;
                    string pattern2 = @"(?'key'[^=]+)=(?'value'[^,]+),?";
                    MatchCollection matches = Regex.Matches(message,pattern2);
                    Dictionary<string, string> dict = matches.Cast<Match>()
                        .GroupBy(x => x.Groups["key"].Value, y => y.Groups["value"].Value)
                        .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                }
            }
     
        }
    }
