	var input = "a-fA-F0-9!";
	var matches = Regex.Matches(input,@".-.|.");
	
	var list = new StringBuilder();
	
	foreach (Match m in matches)
	{
		var value = m.Value;
		
		if (value.Length == 1)
			list.Append(value);
		else
		{
			if (value[2] < value[0]) throw new ArgumentException("invalid format"); // or switch, if you want.
			for (char c = value[0]; c <= value[2]; c++)
				list.Append(c);
		}
	}
	
	Console.WriteLine(list);
