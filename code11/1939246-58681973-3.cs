	private static void Method()
	{
		var dictionary = new Dictionary<string, string>();
		/// populate dictionary here...
		
		dictionary.TryGetValue("Key", string.Empty, out var value);
	}
