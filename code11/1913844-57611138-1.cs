	public static decimal GetInvariantDecimal(string internationDecimalString)
	{
	    return internationDecimalString.Contains(",") ? 
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
