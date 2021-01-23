    public DateTime FirstDayOfMonthFromDateTime(DateTime dateTime)
    {
       return new DateTime(dateTime.Year, dateTime.Month, 1);
    }
    
    
    public DateTime LastDayOfMonthFromDateTime(DateTime dateTime)
    {
       DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
       return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
    }
