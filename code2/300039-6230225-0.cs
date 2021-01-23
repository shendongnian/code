    static IEnumerable<DateTime> GetWorkingHourIntervals(DateTime clockIn, DateTime clockOut)
    {
        yield return clockIn;
        DateTime d = new DateTime(clockIn.Year, clockIn.Month, clockIn.Day, clockIn.Hour, 0, 0).AddHours(1);
        while (d < clockOut)
        {
            yield return d;
            d = d.AddHours(1);
        }
        yield return clockOut;
    }
