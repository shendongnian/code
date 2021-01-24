	string streetName = "patrick portland vic";
	
	string[] split = streetName.Split(' ');
	string[] chars = { "*", "~" };
	
	IEnumerable<IEnumerable<string>> choices = split.Select(n => chars.Select(c => $"{n}{c}"));
	IEnumerable<IEnumerable<string>> result = choices.CartesianProduct();
