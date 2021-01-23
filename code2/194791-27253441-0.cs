        public static DateTime AddWeekDays(this DateTime start, int days)
        {
            int direction = Math.Sign(days);
            int completeWeeks = days / 5;
            int remaining = days % 5;
            DateTime end = start.AddDays(completeWeeks * 7);
            
            for (int i = 0; i < remaining * direction; i++)
            {
                end = end.AddDays(direction * 1);
                while (!IsWeekDay(end))
                {
                    end = end.AddDays(direction * 1);
                }
            }
            return end;
        }
        private static bool IsWeekDay(DateTime date)
        {
            DayOfWeek day = date.DayOfWeek;
            return day != DayOfWeek.Saturday && day != DayOfWeek.Sunday;
        }
