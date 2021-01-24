	public static decimal GetInvariantDecimal(string internationDecimalString)
	{
		var looksUnAmerican = Regex.IsMatch(internationDecimalString, @"(\d+,\d{2}\b)|(\d+\.\d+,\d{0,2})|(\d+\.\d{3})");
		Console.WriteLine(looksUnAmerican);
	    return looksUnAmerican ? 
			Decimal.Parse(internationDecimalString, NumberStyles.Currency, CultureInfo.GetCultureInfo("tr-TR")) :
		    Decimal.Parse(internationDecimalString,  CultureInfo.InvariantCulture);
	}
	
	public static void Main()
	{
		var american = "123.55";
		var international = "234,55";		
		
		Console.WriteLine(GetInvariantDecimal(american));
		Console.WriteLine(GetInvariantDecimal(international));
	}
