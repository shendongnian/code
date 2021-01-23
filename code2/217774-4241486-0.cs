	var source = new []
	{
		"A", "A.B.D", "A",
		"A.B", "E", "F.E",
		"F", "B.C",
		"Q.X", "Q.Y",
		"D.A.A", "D.A.B",
	};
	
	Func<string, int> startsWithCount =
		s => source.Where(x => x.StartsWith(s)).Count();
	
	var results =
		(from x in source.Distinct()
		let xx = x.Split('.')
		let splits = Enumerable
			.Range(1, xx.Length)
			.Select(n => String.Join(".", xx.Take(n)))
		let first = startsWithCount(splits.First())
		select splits
			.Where(s => startsWithCount(s) == first)
			.Last()
		).Distinct();
	
	
	// results == ["A", "E", "F", "B.C", "Q", "D.A"]
