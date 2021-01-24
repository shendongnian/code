    List<int> list = new List<int>();
	list.Add(1);
	list.Add(1);
	list.Add(3);
	
	var items = list.GroupBy(p => p)
        .Select(g => new {
		    Key = g.Key,
			Count = g.Count()
		});
