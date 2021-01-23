    public static IEnumerable<DateTime> GetDateRange(DateTime startDate, DateTime endDate)
    {
        if (endDate < startDate)
            throw new ArgumentException("endDate must be greater than or equal to startDate");
        while (startDate < endDate)
        {
            startDate = startDate.AddDays(1);
            yield return startDate;
        }
    }
