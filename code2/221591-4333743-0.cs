    TimeSpan ts;
    if (TimeSpan.TryParse("12:99", out ts))
    {
        // the string is a valid time, use it
    }
    else
    {
        // the string is not a valid time, handle that scenario
    }
