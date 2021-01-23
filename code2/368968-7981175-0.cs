        public static List<DateTime> ReturnNextNthWeekdaysOfMonth(DateTime dt, DayOfWeek weekday, int amounttoshow = 4)
        {
            List<DateTime> list = new List<DateTime>();
            dt = dt.AddDays(weekday - dt.DayOfWeek);//set to the first day in the list
            for (int i = 0; i < amounttoshow; i++)
            {
                list.Add(dt);
                dt = dt.AddDays(7);
            }
            return list;
        }
