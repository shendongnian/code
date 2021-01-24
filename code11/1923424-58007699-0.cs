    //string value of date
    var iDate = "2012-08-16T19:20:30.456+08:00";  
    
    //Convert.ToDateTime(String)
    //This method will converts the specified string representation of a date and time to an equivalent date and time value
    var dateConversion1 = Convert.ToDateTime(iDate);
    
    //DateTime.Parse()
    //DateTime.Parse method supports many formats. It is very forgiving in terms of syntax and will parse dates in many different formats. That means, this method can parse only strings consisting exactly of a date/time presentation, it cannot look for date/time among text.
    var dateConversion2 = DateTime.Parse(iDate);
    
    //DateTime.ParseExact()
    //ParseExact method will allow you to specify the exact format of your date string to use for parsing. It is good to use this if your string is always in the same format. The format of the string representation must match the specified format exactly.
    var dateConversion3 = DateTime.ParseExact(iDate, "yyyy-MM-dd HH:mm tt", null);
    
    //CultureInfo
    //The CultureInfo.InvariantCulture property is neither a neutral nor a specific culture. It is a third type of culture that is culture-insensitive. It is associated with the English language but not with a country or region.
    var dateConversion4 = DateTime.ParseExact(iDate, "yyyy-MM-dd HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);
    
    //DateTime.TryParse method
    //DateTime.TryParse converts the specified string representation of a date and time to its DateTime equivalent using the specified culture - specific format information and formatting style, and returns a value that indicates whether the conversion succeeded.
    DateTime dateConversion5;
    DateTime.TryParse(iDate, out dateConversion5);
