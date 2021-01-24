		var ranges = new List<GroupRange>
		{
			new GroupRange
			{
				Name = "Today",
				DateRange = (DateTime.Now.Date, DateTime.Now.AddDays(1).AddTicks(-1))
			},
			new GroupRange
			{
				Name = "This Week",
				DateRange = (DateTime.Now.FirstDayOfWeek(), DateTime.Now.LastDayOfWeek())
			},
			new GroupRange
			{
				Name = "Earlier",
				DateRange = (DateTime.MinValue, DateTime.Now.FirstDayOfWeek().AddDays(-1))
			},
		};
		
		var result = ranges
			.Select(r => new 
			{ 
				Period = r.Name,
				Messages = data
					.Where(d => d.ReceivedTime >= r.DateRange.Item1 && 
								d.ReceivedTime <= r.DateRange.Item2)
			});
