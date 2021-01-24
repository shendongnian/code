    var lst = dbContext.JsonSchemas.GetAsNoTracking()
    			.GroupBy(a => new {a.Name, a.Version}).Select(a => new
    			{
    				Id = a.OrderByDescending(s => s.AddedDate).First()
    				Name = a.Key.Name,
    				Version = a.Key.Version,
    				RecentAddedDate = a.OrderByDescending(s => s.AddedDate).First()
    			}).ToList();
