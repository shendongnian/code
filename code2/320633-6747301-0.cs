    DateTime dateTime;
    if (DateTime.TryParseExact(s, "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out dateTime))
    {
        // Process
    }
    else
    {
        // Handle Invalid Date
    }
