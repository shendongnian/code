    string input = "My name is Joe";
    IEnumerable<Tuple<string, string>> result = from c in input.ToCharArray()
                                                where !Char.IsWhiteSpace(c)
                                                group c by Char.ToLower(c)
                                                into g
                                                select
                                                    new Tuple<string, string>(g.Key.ToString(),
                                                                              g.Count().ToString());
    
    int total = result.Select(o => Convert.ToInt32(o.Item2)).Aggregate((i, j) => i + j);
    
    List<Tuple<string, string>> tuples = result.ToList();
    
    tuples.Add(new Tuple<string, string>("Total", total.ToString()));
