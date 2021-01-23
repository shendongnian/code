    public IEnumerable<DateTime> GetMissingMonths(
      DateTime startDate,
      DateTime endDate,
      IEnumerable<DateTime> source)
    {
      IEnumerable<DateTime> sourceMonths =
        source.Select(x => new DateTime(x.Year, x.Month, 1))
              .ToList()
              .Distinct();
      return MonthsBetweenInclusive(startDate, endDate).Except(sourceMonths);
    }
    public IEnumerable<DateTime> MonthsBetweenInclusive(
      DateTime startDate,
      DateTime endDate)
    {
      DateTime currentMonth = new DateTime(startDate.Year, startDate.Month, 1);
      DateTime endMonth = new DateTime(endDate.Year, endDate.Month, 1);
      while(currentMonth <= endMonth)
      {
        yield return currentMonth;
        currentMonth = currentMonth.AddMonths(1);
      }
    }
