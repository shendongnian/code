    var items = new List<Tuple<string, int>>()
    {
    	Tuple.Create("A", 3),
    	Tuple.Create("A", 5),
    	Tuple.Create("B", 1),
    	Tuple.Create("C", 1),
    	Tuple.Create("C", 3),
    	Tuple.Create("C", 2)
    };
    
    var results = items.GroupBy(i => i.Item1)
                       .SelectMany(g => g
                           .Where(i => i.Item2 == g.Max(m => m.Item2)))
                       .Distinct();
