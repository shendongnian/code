    public static IEnumerable<Range> GetRange(DateTime start, DateTime end, DayOfWeek startOfTheWeek = DayOfWeek.Sunday)
    {
        if (start > end)
        {
            throw new ArgumentException();
        }
        DateTime curDay = new DateTime(Math.Min(start.AddDays((6 + (int)startOfTheWeek - (int)start.DayOfWeek) % 7).Ticks, end.Ticks), start.Kind);
        yield return new Range(start, curDay);
        curDay = curDay.AddDays(1);
        while (curDay <= end)
        {
            DateTime nextDay = new DateTime(Math.Min(curDay.AddDays(6).Ticks, end.Ticks), start.Kind);
            yield return new Range(curDay, nextDay);
            curDay = nextDay.AddDays(1);
        }
    }
