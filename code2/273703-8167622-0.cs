    string myDate = "17.11.2011 08:00:00 AM";
	DateTime parsedDate;
    	
	DateTime.TryParseExact(myDate,
                           "dd.MM.yyyy hh:mm:ss tt",
                           CultureInfo.InvariantCulture,
                           System.Globalization.DateTimeStyles.None,
                           out parsedDate);
