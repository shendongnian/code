	List<products> list1 = new List<products>();
	list1.Add(new products("sowmya"));
	list1.Add(new products("Jane"));
	list1.Add(new products("John"));
	list1.Add(new products("kumar"));
	list1.Add(new products("ramya"));
	
	string input = "aaa+kuma+ram";
	List<string> searchStrings =
		input.Split(new string[] { "+" }, StringSplitOptions.None)
		.Select(s => s.ToLower())
		.ToList();
	
	List<products> list2 = (
		from p in list1
		where searchStrings.Any(s => p.Name.Contains(s))
		select p).ToList();
