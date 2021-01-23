	// Note: This could very well be a bad implementation. I'm not too great with Regex.
	static int ExtractNumber(string text)
	{
		Match match = Regex.Match(text, @"(\d+)");
		if (match == null || match.Groups.Count < 2)
		{
			return 0;
		}
		
		int value;
		if (!int.TryParse(match.Groups[1].Value, out value))
		{
			return 0;
		}
		
		return value;
	}
