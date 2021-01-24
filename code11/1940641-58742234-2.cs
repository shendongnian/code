	List<string> strings = new List<string> { "1 2 4.5 72", "1 7..5   3.2.1" };
	foreach (string item in strings)
	{
		if (item.Split (new[] { " " }, StringSplitOptions.RemoveEmptyEntries).All (str => double.TryParse (str, out _)))
		{
			Console.WriteLine ($"{item} has only valid numbers.");
		}
		else
		{
			Console.WriteLine ($"{item} does have invalid numbers.");
		}
	}
    // 1 2 4.5 72 has only valid numbers.
    // 1 7..5   3.2.1 does have invalid numbers.
