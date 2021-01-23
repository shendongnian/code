    public static class DateTimeExtensions
    {
        public static DateTime AddWorkDays(this DateTime date, int workingDays)
        {
            return Observable
                .Generate
                    (date, arg => true, arg => arg.AddDays(workingDays < 0 ? -1 : 1), arg => arg)
                .Where(newDate =>
                    (newDate.DayOfWeek != DayOfWeek.Saturday &&
                     newDate.DayOfWeek != DayOfWeek.Sunday &&
                     !newDate.IsHoliday()))
                .Take(Math.Abs(workingDays) + 1)
                .LastAsync()
                .Wait();
        }
        public static bool IsHoliday(this DateTime date)
        {
            return false;
        }
    }
