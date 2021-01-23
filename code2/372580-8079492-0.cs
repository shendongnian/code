	const string f = "TextFile1.txt";
	// 1
	// Declare new List.
	List<string> lines = new List<string>();
	// 2
	// Use using StreamReader for disposing.
	using (StreamReader r = new StreamReader(f))
	{
	    // 3
	    // Use while != null pattern for loop
	    string line;
	    while ((line = r.ReadLine()) != null)
	    {
		// 4
		// Insert logic here.
		// ...
		// "line" is a line in the file. Add it to our List.
		lines.Add(line);
	    }
	}
