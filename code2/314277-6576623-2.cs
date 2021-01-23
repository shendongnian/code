	ConcurrentList<string> list = new ConcurrentList<string>();
	list.Add("hello");
	list.Add("world");
	list.Add("foo");
	list.Add("bar");
	foreach (string word in list)
	{
		if (word == "world")
		{
			list.Remove("bar"); // Will not crash the foreach!
		}
		Console.WriteLine(word);
	}
