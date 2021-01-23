        public static DateTime GetPreviousWorkingDay(DateTime fromDate)
        {
            while ((fromDate=(fromDate.Date - TimeSpan.FromDays(1))).DayOfWeek == DayOfWeek.Sunday | fromDate.DayOfWeek == DayOfWeek.Saturday)
            {}
            return fromDate;
        }
