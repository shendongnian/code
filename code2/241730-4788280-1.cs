	// Note: This could very well be a bad implementation. I'm not too great with Regex.
	static int ExtractNumber(string text)
	{
		Match match = Regex.Match(text, @"(\d+)");
		if (match == null)
		{
			return 0;
		}
		
		int value;
		if (!int.TryParse(match.Value, out value))
		{
			return 0;
		}
		
		return value;
	}
