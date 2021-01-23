    var list = new List<object>();
	
	list.Add("hello");
	list.Add(1);
	list.Add(new List<bool>());
	
	Console.WriteLine(list.Count());
