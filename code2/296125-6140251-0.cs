        public static DateTime SecondFriday(DateTime currentMonth)
        {
            var day = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            day = FindNext(DayOfWeek.Friday, day);
            day = FindNext(DayOfWeek.Friday, day.AddDays(1));
            return day;
        }
        private static DateTime FindNext(DayOfWeek dayOfWeek, DateTime after)
        {
            DateTime day = after;
            while (day.DayOfWeek != dayOfWeek) day = day.AddDays(1);
            return day;
        }
