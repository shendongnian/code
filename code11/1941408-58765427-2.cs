	// also place this in the Processor class
	public static string Process(string country, string text)
   	{
   		var typeName = $"{typeof(Processors).FullName}+{country}";
   		var processor = (IProcessor)Assembly.GetAssembly(typeof(Processors)).CreateInstance(typeName);
   		return processor?.Process(text);
   	}
