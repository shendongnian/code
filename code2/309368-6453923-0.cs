     string inp = @"1: A C D
                4: A B
                5: D F
                7: A E
                9: B C";
                Dictionary<string, List<int>> res = new Dictionary<string, List<int>>();
                StringReader sr = new StringReader(inp);
                string line;
                while (null != (line = sr.ReadLine()))
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] tokens = line.Split(": ".ToArray(),StringSplitOptions.RemoveEmptyEntries);
                        int idx = int.Parse(tokens[0]);
                        for (int i = 1; i < tokens.Length; ++i)
                        {
                            if (!res.ContainsKey(tokens[i]))
                                res[tokens[i]] = new List<int>();
                            res[tokens[i]].Add(int.Parse(tokens[0]));
                        }
                    }
                }
