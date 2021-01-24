    public bool IsValidDateFormat(string dateFormat)
    {
        return DateTime.TryParseExact("12/31/2019", dateFormat,
            CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
    }
