    /// <summary>
    /// Get last day of month based on date
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DateTime LastDayOfMonth(this DateTime value)
    {
        return new DateTime(value.Year, value.Month, DateTime.DaysInMonth(value.Year, value.Month));
    }
    /// <summary>
    /// Get the first day of month based on date
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DateTime FirstDayOfMonth(this DateTime value)
    {
        return new DateTime(value.Year, value.Month, 1);
    }
