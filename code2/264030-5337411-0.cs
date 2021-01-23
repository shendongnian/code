    public DateTime AddBusinessDays(List<DateTime> businessDays, DateTime startDate, TimeSpan span)
    {
        // Add the initial timespan
        DateTime endDate = startDate.Add(span);
        // Calculate the number of holidays by taking off the number of business days during the period
        int noOfHolidays = span.Days - businessDays.Where(d => d >= startDate && d <= endDate).Count();
        // Add the no. of holidays found
        endDate.AddDays(noOfHolidays);
        return endDate;
    }
