    DateTime dt;
    if(DateTime.TryParseExact("12.12.2011.16.22", "dd.MM.yyyy.HH.mm",
                              CultureInfo.InvariantCulture, DateTimeStyles.None, 
                              out dt))
    {
      // parse successful use dt
    }
