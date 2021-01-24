	var algorithmTypes = AppDomain.CurrentDomain.GetAssemblies()
		.SelectMany(s => s.GetTypes())
		.Where(p => type.IsAssignableFrom(typeof(IAlgorithm)))
		.ToList();
		
	foreach (var algorithmType in algorithmTypes )
	{
		var algorithm = Activator.CreateInstance(algorithmType);
		Console.WriteLine($"Executing algorithm '{algorithm.Name}'...");
		algorithm.Execute();
	}
