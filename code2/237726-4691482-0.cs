    static IEnumerable<DateTime> GetMissingMonths(IEnumerable<DateTime> currentDates, DateTime startDate, DateTime endDate)
    {
        var yearMonths = new HashSet<Tuple<int, int>>(currentDates.Select(d => Tuple.Create(d.Year, d.Month)));
        DateTime current = new DateTime(startDate.Year, startDate.Month, 1);
        if (current < startDate)
            current = current.AddMonths(1);
        while (current <= endDate)
        {
            if (!yearMonths.Contains(Tuple.Create(current.Year, current.Month)))
            {
                yield return current;
            }
            current = current.AddMonths(1);
        }
    }
