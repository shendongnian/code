	DataTable dt = new DataTable();
	da.Fill(dt);
	var listOfData = dt.AsEnumerable()
		.GroupBy(g => new
		{
			length = g["Length"],
			type = g["Type"]
		}).Select(s => new Data
		{
			Metadata = s.Select(m => new FullName {
				FirstName = m["FirstName"].ToString(),
				LastName = m["LastName"].ToString() }).ToList(),
			Length = Convert.ToInt32(s.Key.length),
			Type = s.Key.type.ToString()
		}).ToList();
