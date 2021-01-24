         var dict = new Dictionary<string, string>();
            try
            {
                var lines = email.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                int starts = 0;
                while (!lines[starts + 1].StartsWith("-")) starts++;
                for (int i = starts + 1; i < lines.Length; i += 3)
                {
                    var keys = Regex.Matches(lines[i - 1], @"(?:^| )(\w+\s?)+");
                    var values = Regex.Matches(lines[i + 1], @"(?:^| )(\w+\s?)+");
                    if (keys.Count == values.Count)
                        for (int j = 0; j < keys.Count; j++)
                            dict.Add(keys[j].Value.Trim(), values[j].Value.Trim());
                    else // remove bug if value of first key in a line has no value
                    {
                        if (lines[i + 1].StartsWith(" "))
                        {
                            dict.Add(keys[0].Value.Trim(), "");
                            dict.Add(keys[1].Value.Trim(), values[0].Value.Trim());
                        }
                        else
                        {
                            dict.Add(keys[0].Value, values[0].Value.Trim());
                            dict.Add(keys[1].Value.Trim(), "");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Email is not in correct format");
            }
