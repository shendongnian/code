                string[] inputs = { "**[\"type1\"]", "**[\"type2 type2 type2\"]", "**[\"type3 type3\"]" };
                foreach (string input in inputs)
                {
                    Regex _regex = new Regex("\"([^\"]+)");
                    Match _match = _regex.Match(input);
                    Console.WriteLine(_match.Groups[1].Value);
                }
