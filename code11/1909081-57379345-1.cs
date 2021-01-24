    string[] tokens = mystr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
	List<string> classList = new List<string>();
	for (int i = 0; i < tokens.Length - 1; i++)
	{
		if (tokens[i].Equals("class", StringComparison.InvariantCultureIgnoreCase))
		    classList.Add(tokens[++i]);
	}
