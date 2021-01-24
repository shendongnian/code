    static TimeSpan GetTime(double percentage, TimeSpan startTime, TimeSpan endTime)
    {
        var percentageInTicks = (long)((endTime - startTime).Ticks * percentage);
        return startTime.Add(TimeSpan.FromTicks(percentageInTicks));
    }
