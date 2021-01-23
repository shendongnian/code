    DateTime dt;
    if(DateTime.TryParseExact("12.12.2011.16.22", "dd.MM.yyyy.HH.mm",
                              DateTimeStyles.None, 
                              CultureInfo.InvariantCulture, out dt))
    {
      // parse successful use dt
    }
