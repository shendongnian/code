    var results = days
		.GroupBy(d => d.Date.Year)
		.Select(y => new Year
		{
			YearNumber = y.Key,
			Months = y
				.GroupBy(d => d.Date.Month)
				.Select(m => new Month
				{
					MonthNumber = m.Key,
					Days = m.ToList()
				})
				.ToList()
		})
		.ToList();
