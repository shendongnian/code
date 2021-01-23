	public static List<string> ReadGroup(TextReader tr)
	{
		string line = tr.ReadLine();
		List<string> lines = new List<string>();
		while (line != null && line.Length > 0)
		{
			lines.Add(line);
		}
		// change this to line == null if you have groups with no lines
		if (lines.Count == 0) 
		{
			return null;
		}
		return lines;
	}
