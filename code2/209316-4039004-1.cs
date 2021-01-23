	string src = "for each character in the string, take the rest of the " +
		"string starting from that character " +
		"as a substring; count it if it starts with the target string";
	
	var regex=new Regex(@"\w+",RegexOptions.Compiled);
	var sw=new Stopwatch();
	
	for (int i = 0; i < 100000; i++)
	{
		var dic=regex
			.Matches(src)
			.Cast<Match>()
			.Select(m=>m.Value)
			.GroupBy(s=>s)
			.ToDictionary(g=>g.Key,g=>g.Count());
		if(i==1000)sw.Start();
	}
	Console.WriteLine(sw.Elapsed);
	
	sw.Reset();
	
	for (int i = 0; i < 100000; i++)
	{
		var dic=src
			.Split(' ')
			.GroupBy(s=>s)
			.ToDictionary(g=>g.Key,g=>g.Count());
		if(i==1000)sw.Start();
	}
	Console.WriteLine(sw.Elapsed);
