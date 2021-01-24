	var source = new []
	{
		new { from = new DateTime(2019, 1, 10), to = new DateTime(2019, 1, 12) },
		new { from = new DateTime(2019, 3, 10), to = new DateTime(2019, 3, 14) },
		new { from = new DateTime(2019, 1, 12), to = new DateTime(2019, 1, 13) },
	};
	
	var results =
		source
			.OrderBy(x => x.from)
			.ThenBy(x => x.to)
			.Skip(1)
			.Aggregate(
				source.Take(1).ToList(),
				(a, x) =>
				{
					if (a.Last().to >= x.from)
					{
						a[a.Count - 1] = new { from = a.Last().from, to = x.to };
					}
					else
					{
						a.Add(x);
					}
					return a;
				});
