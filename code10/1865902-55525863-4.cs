    static TimeSpan GetTime(double percentage, DateTime startDate, DateTime endDate)
    {
        var percentageInTicks = (long)((endDate - startDate).Ticks * percentage);
        return startDate.TimeOfDay.Add(TimeSpan.FromTicks(percentageInTicks));
    }
