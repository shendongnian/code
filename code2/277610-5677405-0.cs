    // DateTime to W3C dateTime string
    string formatString= "yyyy-MM-ddTHH:mm:ss.fffffffzzz";
    dateTimeField.ToString(formatString) ;
    // W3C dateTime string to DateTime 
    System.Globalization.CultureInfo cInfo= new System.Globalization.CultureInfo("en-US", true);
    dateTimeField= System.DateTime.ParseExact(stringValue, formatString, cInfo);
