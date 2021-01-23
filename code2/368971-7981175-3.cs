        public static IEnumerable<DateTime> ReturnNextNthWeekdaysOfMonth(DateTime dt, DayOfWeek weekday, int amounttoshow = 4)
        {
            List<DateTime> list = new List<DateTime>();
            if (weekday < dt.DayOfWeek)
                dt = dt.AddDays(7);
            dt = dt.AddDays(weekday - dt.DayOfWeek);
            for (int i = 0; i < amounttoshow; i++)
            {
                list.Add(dt);
                dt = dt.AddDays(7);
            }
            return list;
        }
