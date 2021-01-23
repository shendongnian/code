	var minYear = items.Min(i => i.Year);
	var maxYear = items.Max(i => i.Year);
	
	var names = items.Select(i => i.Name).Distinct();
	
	using (TextWriter writer = …)
	{
		foreach (var name in names)
		{
			writer.Write(name);
		
			for (int y = minYear; y <= maxYear; y++)
			{
				writer.Write(',');
				
				var value = items.Where(i => i.Name == name && i.Year == y)
                                 .Select(i => i.Value)
                                 .SingleOrDefault();
				
				writer.Write(value);
			}
			
			writer.WriteLine();
		}
	}
