	public DateTime ParseDateString(string strDt)
	{
		strDt = strDt.Replace("\/", "");
		// validate string: it must be 7 digits
		if(! (strDt.Length == 7 && strDt.All(ch => char.IsDigit(ch))))
			throw new ArgumentException("Invalid string");
		var days = int.Parse(dt.Substring(4));
		var year = int.Parse(dt.Substring(0, 4));
		
		var date = new DateTime(year, 1, 1);
		return date.AddDays(days - 1);
	}
