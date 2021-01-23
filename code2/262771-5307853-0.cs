    List<string> serverNames = input.Split(',')
                                    .Select(s => {
                                        if (s.StartsWith(@"\\"))
                                            s = s.Substring(2);
                                        if (s.EndsWith("\n"))
                                            s = s.Substring(0, s.Length - 1);
                                        return s;
                                     })
                                    .ToList();
