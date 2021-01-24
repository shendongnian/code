    public bool validateDateAndTime(DateTime checkDateFormat)
    {
    	checkDateFormat = new DateTime(2019, 02, 02, 23, 33, 21);
    	if (DateTime.TryParseExact(checkDateFormat.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AllowWhiteSpaces, out DateTime checkOutDate))
    	{
    		Console.WriteLine($"Validated: {checkOutDate}");
    		return true;
    	}
    	else
    	{
    		Console.WriteLine(checkDateFormat.ToString() + " " + checkOutDate);
    		return false;
    	}
    }
