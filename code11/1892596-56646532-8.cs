	var algorithmTypes = AppDomain.CurrentDomain.GetAssemblies()
		.SelectMany(s => s.GetTypes())
		.Where(p => typeof(IAlgorithm).IsAssignableFrom(p))
		.ToList();
		
	foreach (var algorithmType in algorithmTypes )
	{
		var algorithm = (IAlgorithm)Activator.CreateInstance(algorithmType);
		Console.WriteLine($"Executing algorithm '{algorithm.Name}'...");
		algorithm.Execute();
	}
