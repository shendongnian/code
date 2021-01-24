    public static bool TryParseSpecialDate(string dateString, out DateTime parsedDate)
    {
        parsedDate = DateTime.MinValue;
        // parse yyyy/DDD into 2 separate capture groups
        var match = Regex.Match(dateString ?? string.Empty, @"(\d{4})/(\d{3})");
        if (!match.Success)
        {
            return false;
        }
        // Create a date for yyyy/01/01
        var yearDate = new DateTime(int.Parse(match.Groups[1].Value), 1, 1);
        var dayOfYear = int.Parse(match.Groups[2].Value);
        // Add the required number of days
        var result = yearDate.AddDays(dayOfYear - 1);
        // Check that it's the same year (so that 2019/888 won't work, or 366 in a non leap year)
        if (result.Year != yearDate.Year)
        {
            return false;
        }
        // Set the date and return it
        parsedDate = result;
        return true;
    }
