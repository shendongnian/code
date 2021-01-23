    void Main()
    {
    	var dt = "15/03/2046";
    	
    	dt.ToDateTime("fr-FR", DateTime.Now).Dump();
    }
    
    public static class Extensions
    {
    	public static DateTime ToDateTime(this string dateTime, string culture, DateTime defaultValue)
    	{
    		DateTime dt;
    
    		if (DateTime.TryParse(dateTime,  System.Globalization.CultureInfo.CreateSpecificCulture(culture), System.Globalization.DateTimeStyles.None, out dt))
    			return dt;
    		else
    			return defaultValue;
    	}
    }
