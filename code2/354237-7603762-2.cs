    public enum EventTimings : int
    {
        Default = 12,           // Default every 12 hours.
        NoonAndMidnight = 12,   // Every 12 hours.
        Weekly = 168,           // 168 hours in a week.
        ThirtyDays = 720        // 720 hours in 30 days.
    }
    public DateTime CalculateDateTime(DateTime starting, EventTimings timing)
    {
        return CalculateDateTime(starting, TimeSpan.FromHours((int)timing));
    }
    public DateTime CalculateDateTime(DateTime starting, TimeSpan span)
    {
        DateTime baseTime = new DateTime(starting.Year, starting.Month, starting.Day, starting.Hour >= 12 ? 12 : 0, 0, 0);
        return baseTime.Add(span);
    }
