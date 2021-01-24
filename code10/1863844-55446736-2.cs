      var dict = new Dictionary<string, string>();
                try
                {
                    var lines = email.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    int starts = 0, end = 0, length = 0;
                    while (!lines[starts + 1].StartsWith("-")) starts++;
                    for (int i = starts + 1; i < lines.Length; i += 3)
                    {
                        var mc = Regex.Matches(lines[i], @"(?:^| )-");
                        foreach (Match m in mc)
                        {
                            int start = m.Value.StartsWith(" ") ? m.Index + 1 : m.Index;
                            end = start;
                            while (lines[i][end++] == '-' && end < lines[i].Length - 1) ;
                            length = Math.Min(end - start, lines[i - 1].Length - start);
                            string key = length > 0 ? lines[i - 1].Substring(start, length).Trim() : "";
                            end = start;
                            while (lines[i][end++] == '-' && end < lines[i].Length) ;
                            length = Math.Min(end - start, lines[i + 1].Length - start);
                            string value = length > 0 ? lines[i + 1].Substring(start, length).Trim() : "";
                            dict.Add(key, value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Email is not in correct format");
                }
