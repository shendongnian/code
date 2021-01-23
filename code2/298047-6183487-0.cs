	public static Boolean isAlphaNumeric(string strToCheck)
	{
		Regex rg = new Regex(@"^[a-zA-Z0-9\s,]*$");
		return rg.IsMatch(strToCheck);
	}
