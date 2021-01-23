	public string GetRegexError(string _regexPattern, RegexOptions _regexOptions)
	{
		try
		{
			Regex _regex = new Regex(_regexPattern, _regexOptions);
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
		return "";
	}
