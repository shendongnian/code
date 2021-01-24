	var listOfData = ds.Tables["TableName"].AsEnumerable()
		.GroupBy(g => new
		{
			length = listOfLength,
			type = listOfType
		})
		.Select(s => new 
		{
			MetaData = s.Select(m => new {
				Key = m["FirstName"].ToString(),
				Value = m["LastName"].ToString()
			}).ToList(),
			Length = Convert.ToInt32(s.Key.length),
			Type = s.Key.type.ToString()
		});
