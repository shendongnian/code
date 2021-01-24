    public static TimeSpan CustomParse(string input)
    {
        // Split the string on the ':' character
        var parts = input?.Split(':');
        // Make sure we have something to work with
        if (parts == null || parts.Length == 0) 
            throw new FormatException("input format must be \"%m:%s\" or \"%s\"");
        int seconds;
        // Only a single number represents seconds
        if (parts.Length == 1)
        {
            if (int.TryParse(parts[0], out seconds))
            {
                return TimeSpan.FromSeconds(seconds);
            }
        }
        // Otherwise the first number is minutes and the second one is seconds
        else
        {
            int minutes;
            if (int.TryParse(parts[0], out minutes) &&
                int.TryParse(parts[1], out seconds))
            {
                return TimeSpan.FromSeconds(seconds).Add(TimeSpan.FromMinutes(minutes));
            }
        }
        // If we haven't returned anything yet, there was an error in the format
        throw new FormatException("input format must be \"%m:%s\" or \"%s\"");
    }
