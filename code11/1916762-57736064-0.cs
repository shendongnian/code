	var array = JsonConvert.DeserializeAnonymousType("[" + input + "]" , (string[][])null);
	Console.WriteLine("There were {0} rows with {1} columns", array.Length, array[0].Length);
	var list = new List<Dictionary<string,string>>();
	for (var i = 1; i<= array.GetUpperBound(0); i++)
	{
		var dictionary = array[0]
			.Zip(array[i], (l,r) => new KeyValuePair<string,string>(l,r))
			.ToDictionary( pair => pair.Key, pair => pair.Value);
		list.Add(dictionary);
	}
		
	Console.WriteLine("We now have a list of {0} rows", list.Count);
		
	for (int i=0; i<list.Count; i++)
	{
		Console.WriteLine("\r\nHere is row {0}\r\n", i);
		var dictionary = list[i];
		foreach (var key in dictionary.Keys)
		{
			Console.WriteLine("{0} = {1}", key, dictionary[key]);
		}
	}
