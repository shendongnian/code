	var merged = new { datapoints = Enumerable.Empty<object []>() };
	foreach (var str in jsonSeriesList)
	{
		var item = JsonConvert.DeserializeAnonymousType(str, merged);
		merged = new 
		{ 
			datapoints = merged.datapoints.Concat(item.datapoints)
				// Group them by the first array item.
				// This will throw an exception if any of the arrays are empty.
				.GroupBy(i => i[0])
				// And create a combined array consisting of the key (the first item from all the grouped arrays)
				// and all remaining subsequent items in the grouped arrays.
				.Select(g => new [] { g.Key }.Concat(g.SelectMany(i => i.Skip(1))).ToArray())
		};
	}
	var mergedJson = JsonConvert.SerializeObject(merged);
