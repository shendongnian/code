	public DateTime ParseDateString(string strDt)
	{
		// validate string, pattern explanation:
        // \d - match sigle digit
        // ^ - match beginning of a string
        // $ - match end of a string
        // /? - match zero or one /
		if(! Regex.Match(strDt, @"^\d\d\d\d/?\d\d\d$").Success)
			throw new ArgumentException("Invalid string");
        // get rid of a optional /
        strDt = strDt.Replace("/", "");
		var days = int.Parse(dt.Substring(4));
		var year = int.Parse(dt.Substring(0, 4));
		
		var date = new DateTime(year, 1, 1);
		return date.AddDays(days - 1);
	}
