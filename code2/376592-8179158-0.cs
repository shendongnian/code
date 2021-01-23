    DateTime value;
    if (DateTime.TryParseExact(text, "dd-MM-yyyy",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.AssumeUniversal,
                               out value))
    {
         // Value will now be midnight UTC on the given date
    }
    else
    {
        // Parsing failed - invalid data
    }
