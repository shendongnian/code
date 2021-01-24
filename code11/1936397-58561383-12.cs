	var listOfData = ds.Tables["TableName"].AsEnumerable()
		.GroupBy(g => new
		{
			length = listOfLength,
			type = listOfType
		})
		.Select(s => new Data
		{
			Metadata = s.Select(m => new FullName {
				FirstName = m["FirstName"].ToString(),
				LastName = m["LastName"].ToString() }).ToList(),
			Length = Convert.ToInt32(s.Key.length),
			Type = s.Key.type.ToString()
		});
