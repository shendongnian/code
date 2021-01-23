    void SmartSplit(string input, int maxLength, List<string> results)
    {
	    if (input.Length < maxLength)
		    results.Add(input);
	    else
	    {
		    int index = input.LastIndexOf(' ', maxLength);
		    results.Add(input.Substring(0, index));
		    SmartSplit(input.Substring(index + 1), maxLength, results);
	    }
    }
