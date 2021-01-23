	static string PreProcess(string htmlInput)
	{
		// Stores the index of the last unclosed '<' character, or -1 if the last '<' character is closed.
		int lastGt = -1; 
		
		// This list will be populated with all the unclosed '<' characters.
		List<int> gtPositions = new List<int>();
		// Collect the unclosed '<' characters.
		for (int i = 0; i < htmlInput.Length; i++)
		{
			if (htmlInput[i] == '<')
			{
				if (lastGt != -1)
					gtPositions.Add(lastGt);
				lastGt = i;
			}
			else if (htmlInput[i] == '>')
				lastGt = -1;
		}
		if (lastGt != -1)
			gtPositions.Add(lastGt);
		// If no unclosed '<' characters are found, then just return the input string.
		if (gtPositions.Count == 0)
			return htmlInput;
		
		// Build the output string, replace all unclosed '<' character by "&lt;".
		StringBuilder htmlOutput = new StringBuilder(htmlInput.Length + 3 * gtPositions.Count);
		int start = 0;
		foreach (int gtPosition in gtPositions)
		{
			htmlOutput.Append(htmlInput.Substring(start, gtPosition - start));
			htmlOutput.Append("&lt;");
			start = gtPosition + 1;
		}
		htmlOutput.Append(htmlInput.Substring(start));
		return htmlOutput.ToString();
	}
