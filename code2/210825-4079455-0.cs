        public static DateTime First(this DateTime current)
        {
            DateTime first = current.AddDays(1 - current.Day);
            return first;
        }
        public static DateTime First(this DateTime current, DayOfWeek dayOfWeek)
        {
            DateTime first = current.First();
            if (first.DayOfWeek != dayOfWeek)
            {
                first = first.Next(dayOfWeek);
            }
            return first;
        }
        public static DateTime Last(this DateTime current)
        {
            int daysInMonth = DateTime.DaysInMonth(current.Year, current.Month);
            DateTime last = current.First().AddDays(daysInMonth - 1);
            return last;
        }
