    public IEnumerable GetMonths(DateTime currentDate, IFormatProvider provider)
    {
        return from i in Enumerable.Range(0, 12)
               let now = currentDate.AddMonths(i)
               select new
               {
                   MonthLabel = now.ToString("MMMM", provider),
                   Month = now.Month,
                   Year = now.Year
               };
    }
