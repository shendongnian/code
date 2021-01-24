    // A SortedDictionary is like a Dictionary, but automatically sorted on the key
	var dict = new SortedDictionary<(int, string), List<string>>();
		
	var key = (23, "Harry");
    // If you are using .NET Core 2.0 or above, you can use
    /*
     * if (!dict.TryAdd(key, new List<string> { "Ottawa", "Green" }))
     *     Console.WriteLine($"Can't add {key}");
     */
	if (!dict.ContainsKey(key))
		dict.Add(key, new List<string> { "Ottawa", "Green" });
	else
		Console.WriteLine($"Can't add {key}");
		
	key = (4, "Harry");
	if (!dict.ContainsKey(key))
		dict.Add(key, new List<string> { "Durban", "Blue" });
	else
		Console.WriteLine($"Can't add {key}");
		
	key = (4, "Harry");
	if (!dict.ContainsKey(key))
		dict.Add(key, new List<string> { "this is", "duplicate" });
	else
		Console.WriteLine($"Can't add {key}");
		
	key = (17, "Amy");
	if (!dict.ContainsKey(key))
		dict.Add(key, new List<string> { "Venice", "Red" });
	else
		Console.WriteLine($"Can't add {key}");
		
	key = (17, "Sue");
	if (!dict.ContainsKey(key))
		dict.Add(key, new List<string> { "Sydney", "Blue" });
	else
		Console.WriteLine($"Can't add {key}");
		
	Console.WriteLine("---------------------------------------");
	Console.WriteLine("Notice now how sorted is the dictionary");
	Console.WriteLine("---------------------------------------");
	foreach (var Key in dict.Keys)
	{
		Console.WriteLine($"dict[{Key}] Contains : ");
		foreach (var val in dict[Key])
		{
			Console.WriteLine($"\t{val}");
		}
	}
