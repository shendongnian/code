    string input = "There are 4 numbers in this string: 40, 30, and 10.";
	// Split on one or more non-digit characters.
	string[] numbers = Regex.Split(input, @"\D+");
	foreach (string value in numbers)
	{
	    if (!string.IsNullOrEmpty(value))
	    {
		int i = int.Parse(value);
		Console.WriteLine("Number: {0}", i);
	    }
	}
