    IEnumerable<DateTime> GetDateRange(DateTime startDate, DateTime endDate)
    {
        DateTime lastDate = endDate.Date;
        DateTime date = startDate.Date;
        while (date <= lastDate)
        {
            yield return date;
            date = date.AddDays(+1);
        }
    }
