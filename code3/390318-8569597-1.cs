	var list = new List<Entry>();
	var e = new Entry();
	e.Set(12312);
	list.Add(e);
	Console.WriteLine(list[0].Get()); // outputs 12312
