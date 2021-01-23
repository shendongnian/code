    private static DateTime GetPreviousSpecifiedDayOfWeek(DateTime dt, DayOfWeek day)
        {
            while (dt.DayOfWeek != day)
            {
                dt = dt.AddDays(-1);
            }
            return dt;
        }
