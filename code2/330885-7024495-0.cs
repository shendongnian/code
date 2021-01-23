    var sequences = new List<Tuple<int, int>>
        {
            new Tuple<int, int>(1, 10),
            new Tuple<int, int>(8, 101),
            new Tuple<int, int>(102, 103),
            new Tuple<int, int>(104, 104),
            new Tuple<int, int>(110, 200)
        };
    var missing = new List<int>();
    var overlap = new List<int>();
    
    sequences.Aggregate((prev, current) => {
    	if (prev.Item2 >= current.Item1) {
    		overlap.AddRange(Enumerable.Range(current.Item1, prev.Item2 - current.Item1 + 1));
    	}
    	if (current.Item1 > prev.Item2 + 1) {
    		missing.AddRange(Enumerable.Range(prev.Item2 + 1, current.Item1 - prev.Item2 - 1));
    	}
    	return current;
    });
