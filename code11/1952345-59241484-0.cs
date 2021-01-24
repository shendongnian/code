	List<DateTime> contiguousDates = new List<DateTime>
	{
		new DateTime(2019, 12, 24),
		new DateTime(2019, 12, 25),
		new DateTime(2019, 12, 26),
		new DateTime(2020, 01, 04),
		new DateTime(2020, 01, 05),
		new DateTime(2020, 01, 10),
	};
		
	var result = 
		contiguousDates
			.Skip(1)
			.Zip(contiguousDates, (x1, x0) => new { x1, x0 })
			.StartWith(new { x1 = contiguousDates.First(), x0 = contiguousDates.First().AddDays(-1.0) })
			.TakeWhile(x => x.x1.Subtract(x.x0).TotalDays == 1.0)
			.Select(x => x.x1)
			.ToList();
