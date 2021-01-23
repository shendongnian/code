    var rawData = new []
    {
    	new { Id = 1, Description = "test1" },
    	new { Id = 1, Description = "test2" },
    	new { Id = 2, Description = "test3" },
    	new { Id = 2, Description = "test4" },
    	new { Id = 3, Description = "test4" },
    };
    
    var result = from data in rawData
    	group data by data.Id into g
	select new { g.Key, Descriptions = string.Join(",", g.Select(i => i.Description)) };
    	
    result.Dump();
