	var values = new [] { 13, 18, 13, 12, 13, 17, 17, 18, 19, 20, 18, 17, 17, 12, 13, 15, 17, 16, 16, 19, 18, 19, 20, 19, 18, 16, 11, 13, 19, 14, 12 };
	
	var extended = new [] { 0 }.Concat(values).Concat(new [] { 0 }).ToArray();
	
	var results =
		Enumerable
			.Range(0, values.Length)
			.Select(x => values.Skip(x).Take(3).ToArray())
			.Where(x => x.Length == 3)
			.Select(x => x[1] >= 17 && (x[0] >= 17 || x[2] >= 17) ? x[1] : 0)
			.Aggregate(new List<List<int>>(), (a, x) =>
			{
				if (x == 0)
					a.Add(new List<int>());
				else
					a.Last().Add(x);
				return a;
			})
			.Where(x => x.Count > 0)
			.Select(x => x.Sum())
			.ToArray();
