	// also place these in the Processors class above
	public static IProcessor CreateProcessor(string country)
	{
		var typeName = $"{typeof(Processors).FullName}+{country}";
		var processor = (IProcessor)Assembly.GetAssembly(typeof(Processors)).CreateInstance(typeName);
		return processor;
	}
	public static string Process(string country, string text)
	{
		var processor = CreateProcessor(country);
		return processor?.Process(text);
	}
