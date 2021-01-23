    DateTime dateValue;
    if(DateTime.TryParseExact("201009", "yyyyMM", CultureInfo.InvariantCulture, 
                           DateTimeStyles.None, out dateValue))
    {
       // DateTime parsed...
    }
