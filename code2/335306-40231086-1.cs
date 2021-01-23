    var itemsOne = new[] {
		new { Name = "A", Level = 1 },
		new { Name = "B", Level = 2 },
		new { Name = "C", Level = 3 },
		new { Name = "D", Level = 4 }
	}.ToDictionary(i => i.Name, i => i);
	var itemsTwo = new[] {
		new { Name = "C", Level = 10 },
		new { Name = "D", Level = 20 },
		new { Name = "E", Level = 30 },
		new { Name = "F", Level = 40 }
	}.ToDictionary(i => i.Name, i => i);
	
	itemsOne
	.Combine(itemsTwo,
		kvp => kvp.Value.Level <= 3,
		kvp => kvp.Value.Level <= 30)
		.ToDictionary(d => d.Key, d=> d.Value.Level)
