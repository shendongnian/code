    var query = from row in table.AsEnumerable()
		group row by new { Date = row["Date"], Price1 = row["Price1"] }  into g
		select new
		{
			Date = g.Key.Date,
			Price = g.Key.Price1,
			Count = g.Count()
		};
