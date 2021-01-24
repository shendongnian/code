	var objects = new[]
	{
		new { StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(10, 0, 0) },
		new { StartTime = new TimeSpan(9, 30, 0), EndTime = new TimeSpan(10, 15, 0) },
		new { StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(10, 30, 0) },
		new { StartTime = new TimeSpan(11, 0, 0), EndTime = new TimeSpan(11, 30, 0) },
		new { StartTime = new TimeSpan(11, 45, 0), EndTime = new TimeSpan(13, 0, 0) },
		new { StartTime = new TimeSpan(12, 45, 0), EndTime = new TimeSpan(14, 0, 0) },
	};
	
	var results = // List<{ StartTime = ..., EndTime = ... }>
		objects
			.Skip(1)
			.Aggregate(
				objects.Take(1).ToList(),
				(a, x) =>
				{
					if (a.Last().EndTime > x.StartTime)
					{
						a[a.Count - 1] = new
						{
							a.Last().StartTime,
							EndTime =
								a.Last().EndTime > x.EndTime
								? a.Last().EndTime
								: x.EndTime
						};
					}
					else
					{
						a.Add(x);
					}
					return a;
				});
