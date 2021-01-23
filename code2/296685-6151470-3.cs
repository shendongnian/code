    string input = "My name is Joe";
    
    var result = from c in input.ToCharArray()
                 where !Char.IsWhiteSpace(c)
                 group c by Char.ToLower(c)
                 into g
                 select new Tuple<string, int>(g.Key.ToString(),g.Count());
    
    int total = result.Select(o => o.Item2).Aggregate((i, j) => i + j);
    
    List<Tuple<string, int>> tuples = result.ToList();
    
    tuples.Add(new Tuple<string, int>("Total", total));
