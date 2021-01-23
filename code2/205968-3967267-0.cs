    DateTime date;
    if (DateTime.TryParseExact(text, "dd'.'MM'.'yyyy",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None,
                               out date))
    {
       // Success
    }
    else
    {
       // Parse failed
    }
