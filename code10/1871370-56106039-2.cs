	private static FooBar Parse(string value)
	{
		// a basic check for null or empty string
		if (String.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));
		
		// split the string
		string[] split = value.Split(',');
	
		// a basic check for properly formed key/value pairs in the string
		if (split.Length < 2 || split.Length % 2 != 0)
			throw new ArgumentException("Malformed string.", nameof(value));
	
		// put the values into our object
		var result = new FooBar();
		
		// Foo pair
		result.FooID = Int32.Parse(split[0]);
		result.FooProperty1 = split[1];
		
		// Bar pairs
		result.Bars = new List<Bar>();
		for (int i = 2; i < split.Length; i = i + 4)
		{
			result.Bars.Add(new Bar()
			{
				BarID = split[i],
				BarProperty1 = split[i+1],
				BarProperty2 = split[i+2],
				BarProperty3 = split[i+3]
			});
		}
		
		return result;
	}
