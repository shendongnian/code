    public IEnumerable<DateTime> GetMissingMonths(
      DateTime startDate,
      DateTime endDate,
      IEnumerable<DateTime> source)
    {
      source = source.Select(x => new DateTime(x.Year, x.Month, 1))
        .ToList().Distinct();
      return MonthsBetweenInclusive(startDate, endDate).Except(source);
    }
    public IEnumerable<DateTime> MonthsBetweenInclusive(
      DateTime startDate,
      DateTime endDate)
    {
      currentDate = new DateTime(startDate.Year, startDate.Month, 1);
      endDate = new DateTime(endDate.Year, endDate.Month, 1);
      while(currentDate <= endDate)
      {
        yield return currentDate;
        currentDate = currentDate.AddMonths(1);
      }
    }
