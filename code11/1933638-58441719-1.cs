	using (IDataReader reader = cmd.ExecuteReader())
	{
		var query = reader
			.SelectRows(r => 
						new
						{
							id = r.GetInt64(r.GetOrdinal("pid")),
							name = r["contributor"].ToString(),
							project = new {id = r.GetInt64(r.GetOrdinal("projectID")), name = r["projectName"].ToString() },
						}
					   )
			.GroupBy(r => new { r.id, r.name })
			.Select(g => new { g.Key.id, g.Key.name, projects = g.Select(i => i.project) });
			
		var json = JsonConvert.SerializeObject(new { contributors = query }, Formatting.Indented);
		
		Console.WriteLine(json);
	}
