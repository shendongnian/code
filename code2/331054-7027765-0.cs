    DateTime dateTime;
    if (DateTime.TryParseExact(text, "yyyyMMdd'T'HHmmsszzzz",
                               CultureInfo.InvariantCulture, out dateTime))
    {
        // All was okay
    }
    else
    {
        // Handle failure
    }
