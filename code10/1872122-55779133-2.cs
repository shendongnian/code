    DateTime dt;
    
    if(!DateTime.TryParseExact(dateTimeStr,
                           "dd/M/yyyy hh:m:ss",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None,
                            out dt))
    {
    	_logger.Log($"Exception while parsing {dateTimeStr}");
    	dt = DateTime.Now;
    }
    
    return dt;
