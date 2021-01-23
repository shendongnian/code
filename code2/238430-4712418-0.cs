    public static DateTime ConvertDate(string date, string pattern)
    {
        DateTime retval = DateTime.MinValue;
        if (System.DateTime.TryParseExact(date, pattern, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out retval))
           return retval;
        
        // Could not convert date..
        return DateTime.MinValue;
    }
      
    DateTime myDate = ConvertDate("20101230", "yyyyMMdd");
