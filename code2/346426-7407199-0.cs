    static class DateTimeExtensions {
        private static IEnumerable<DateTime> DaysOfMonth(int year, int month) {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                             .Select(day => new DateTime(year, month, day));
        }
        public static DateTime NthDayOfMonthFrom(
            this List<DayOfWeek> daysOfWeek,
            int year,
            int month,
            int nth
        ) {
            return
                DateTimeExtensions.DaysOfMonth(year, month)
                                  .Where(
                                       date => daysOfWeek.Contains(date.DayOfWeek)
                                  )
                                  .Skip(nth - 1)
                                  .First();
        }
    }
