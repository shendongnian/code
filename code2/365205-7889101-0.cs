	public void LoadContent(XDocument doc, TileMap myMap)
	{
		var lookup = new Dictionary<string, Action<string>>()
		{
			{ "E", v => { Console.WriteLine("E  = " + v); } },
			{ "ID", v => { Console.WriteLine("ID = " + v); } },
			{ "B", v => { Console.WriteLine("B  = " + v); } },
			{ "H", v => { Console.WriteLine("H  = " + v); } },
			{ "T", v => { Console.WriteLine("T  = " + v); } },
		};
		
		var actions =
			from e in doc.Root
				.Element("Asset")
				.Element("R")
				.Elements("Item")
				.Elements("C")
			from mv in e
				.Elements("Item")
				.Elements()
			let name = mv.Name.ToString()
			let value = mv.Value
			select new Action(() => lookup[name](value));
		
		foreach (var a in actions)
			a.Invoke();
	}
