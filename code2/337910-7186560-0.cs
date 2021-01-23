	Dictionary<string, string> d = new Dictionary<string, string>();
	d.Add("Fred", "555-5555");
	d.Add("Harry", "555-5556");
	// See if Dictionary contains this string
	if (d.ContainsKey("Fred")) // True
	{
	    string number = d["Fred"];
	    Console.WriteLine(number);
	}
	// See if Dictionary contains this string
	if (d.ContainsKey("Jim"))
	{
	    Console.WriteLine(false); // Nope
	}
