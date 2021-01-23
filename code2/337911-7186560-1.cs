	Dictionary<string, string> phonebook = new Dictionary<string, string>();
	phonebook.Add("Fred", "555-5555");
	phonebook.Add("Harry", "555-5556");
	// See if Dictionary contains this string
	if (phonebook.ContainsKey("Fred")) // True
	{
	    string number = phonebook["Fred"];
	    Console.WriteLine(number);
	}
	// See if Dictionary contains this string
	if (phonebook.ContainsKey("Jim"))
	{
	    Console.WriteLine("Not in phonebook"); // Nope
	}
