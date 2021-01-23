    string str = "20111021";
    string[] format = {"yyyyMMdd"};
    DateTime date;
    
    if (DateTime.TryParseExact(str, 
                               format, 
                               System.Globalization.CultureInfo.InvariantCulture,
                               System.Globalization.DateTimeStyles.None, 
                               out date))
    {
         //valid
    }
