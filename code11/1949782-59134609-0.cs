               string input = "Resting HR(bpm): 62 Resting BP(mmHg): 120/90 MaxPER: 60 Target HR(Nun): 180";
                string pattern = @"(?'name'[^\s]+):\s+(?'value'[^\s]+)";
                MatchCollection matches = Regex.Matches(input, pattern);
                Dictionary<string, string> dict = matches.Cast<Match>()
                    .GroupBy(x => x.Groups["name"].Value, y => y.Groups["value"].Value)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                foreach (KeyValuePair<string, string> measurement in dict)
                {
                    Console.WriteLine("Measurement : '{0}', Value : '{1}'", measurement.Key, measurement.Value);
                }
                Console.ReadLine();
