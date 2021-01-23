    public static List<DateTime> GetDates(int year, int month)
    {
       return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                        .Select(day => new DateTime(year, month, day))
                        .Where(dt => dt.DayOfWeek != DayOfWeek.Sunday &&
                                     dt.DayOfWeek != DayOfWeek.Saturday)
                        .ToList();
    }
