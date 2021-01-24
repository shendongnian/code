    Dictionary<string, List<string>> demo = new Dictionary<string, List<string>>();
	List<String> key1val= new List<string>();
	key1val.Add("1");
	key1val.Add("2");
	key1val.Add("3");
	List<String> key2val= new List<string>();
	key2val.Add("4");
	key2val.Add("5");
	demo.Add("key1", key1val);
	demo.Add("key2", key2val);
		
	foreach (var key in demo.Keys)
	{
		Console.WriteLine(key);
		foreach (var elem in demo[key])
		{
			Console.WriteLine(elem);
		}
	}
