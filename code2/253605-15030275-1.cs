    private static DateTime GetPreviousSpecifiedDayOfWeek(DateTime dt, DayOfWeek day)
        {
            if (dt.DayOfWeek == day)
            {
                return dt;
            }
            while (dt.DayOfWeek != day)
            {
                dt = dt.AddDays(-1);
            }
            return dt;
        }
