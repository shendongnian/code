	var parsed = new ParsedInput(input);
	string word = "";
	if (parsed.TryGetWord(index, out word))
	{
		// A word exists at the given index, do something.
	}
	else
	{
		// Handle missing word at the given index (optional).
	}
