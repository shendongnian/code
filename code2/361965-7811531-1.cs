    public static IEnumerable<Range> GetRange(DateTime start, DateTime end, DayOfWeek startOfTheWeek = DayOfWeek.Sunday)
    {
        if (start > end)
        {
            throw new ArgumentException();
        }
        // We "round" the dates to the beginning of the day each
        start = start.Date;
        end = end.Date;
        // The first week. It could be "shorter" than normal. We return it "manually" here
        // The 6 + startOfWeek - start.DayOfWeek will give us the number of days that you
        // have to add to complete the week. It's mod 7. It's based on the idea that 
        // the starting day of the week is a parameter.
        DateTime curDay = new DateTime(Math.Min(start.AddDays((6 + (int)startOfTheWeek - (int)start.DayOfWeek) % 7).Ticks, end.Ticks), start.Kind);
        yield return new Range(start, curDay);
        curDay = curDay.AddDays(1);
        while (curDay <= end)
        {
            // Each time we add 7 (SIX) days. This is because the difference between
            // as considered by the problem, it's only 6 * 24 hours (because the week
            // doesn't end at 23:59:59 of the last day, but at the beginning of that day)
            DateTime nextDay = new DateTime(Math.Min(curDay.AddDays(6).Ticks, end.Ticks), start.Kind);
            yield return new Range(curDay, nextDay);
            // The start of the next week
            curDay = nextDay.AddDays(1);
        }
    }
