	List<string> list = (new string[] { 
		"Shekhar1", "Shekhar2", "Shekhar3", "Shekhar4", "Shekhar5" }
	).ToList();
	string match = "Shekhar3";
	string replace = "Shekhar88";
	List<string> newList = list.Select(x => x == match ? replace : x).ToList();
	list = newList;
	foreach (string value in list) {
		Console.WriteLine("{0}", value);
	}
