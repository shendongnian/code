    public IEnumerable<DateTime> GetMissingMonths(
      DateTime start,
      DateTime end,
      IEnumerable<DateTime> source)
    {
      return AllMonths(start, end).Except(source.Select(x => x.Month));
    }
    public IEnumerable<DateTime> MonthsBetweenInclusive(DateTime start, DateTime end)
    {
      current = start.Month;
      end = end.Month;
      while(current <= end)
      {
        yield return current;
        current = current.AddMonths(1);
      }
    }
