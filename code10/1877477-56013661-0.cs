	db.NAME_OF_THE_TABLE
		.ToArray() // materialize the query, since this group by is unlikely to be supported by linq2...
		.GroupBy(x => new { x.Id, x.Year }, (k, g) =>
		{
			var months = new { First = g.Min(x => x.Month), Last = g.Max(x => x.Month) };
			
			// left join to fill the blank between the records
			return (
				from month in Enumerable.Range(months.First, months.Last - months.First + 1)
				join row in g on month equals row.Month into match
				from x in match.DefaultIfEmpty(new TYPE_OF_RECORD { Id = k.Id, Year = k.Year, Month = month, Total = 0 })
				select x
			);
		})
		.SelectMany(g => g) // flatten the grouping
