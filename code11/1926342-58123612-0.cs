	private static IEnumerable<string> ParseTokens(string input)
	{
		return input
			// removes the leading {
			.TrimStart('{')
			// removes the trailing }
			.TrimEnd('}')
			// splits on the different token in the middle
			.Split( new string[] { "},{" }, StringSplitOptions.None );
	}
