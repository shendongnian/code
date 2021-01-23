	public static string TrimTo(string str, int maxLength)
	{
		if (str.Length <= maxLength)
		{
			return str;
		}
		return str.Substring(0, maxLength);
	}
