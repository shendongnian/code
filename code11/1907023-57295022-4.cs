    string str = "abcdef";
    string input = str.ToLower();
    var dict = "abcdefghijklmnopqrstuvwxyz".ToDictionary(k => k, v => 0);
	
	foreach (char c in input)
	{
		dict[c]++;
	}
	
	var output = new int[dict.Count];	
	var index = 0;
	
	foreach (var key in dict.Keys.OrderBy(k => k))
	{
		output[index++] = dict[key];
	}
