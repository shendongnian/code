	var d = new Dictionary<string, int>()
	{
		{ "A", 2 },
		{ "B", 2 },
		{ "Z", 2 },
		{ "A_B", 1 },
		{ "A_B_C", 5 },
	};
	var d2 = d.Select(kvp => new KeyValuePair<string, int>(
					kvp.Key,
					d.Where(k => k.Key.StartsWith(kvp.Key))
					 .Sum(k => k.Value)))
			  .ToDictionary(kvp => kvp.Key);
