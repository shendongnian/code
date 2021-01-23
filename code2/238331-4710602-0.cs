    static bool ValidateTime(string time, string format)
    {
        DateTime outTime;
        return DateTime.TryParseExact(time, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out outTime);
    }
