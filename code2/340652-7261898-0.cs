    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var date in DayOfWeek.Monday.OccurrencesInMonth(year: 2011, month: 8))
            {
                Console.WriteLine(date);
            }
        }
    }
    public static class DayOfWeekExtensions
    {
        public static IEnumerable<DateTime> OccurrencesInMonth(this DayOfWeek targetDayOfWeek, int year, int month)
        {
            var firstDayInYear = new DateTime(year, month, 1);
            var currentDay = firstDayInYear.Next(targetDayOfWeek);
            while (currentDay.Month == month)
            {
                yield return currentDay;
                currentDay = currentDay.AddDays(7);
            }
        }
    }
    public static class DateTimeExtensions
    {
        public static DateTime Next(this DateTime current, DayOfWeek dayOfWeek)
        {
            int offsetToNextOccurrence = dayOfWeek - current.DayOfWeek;
            if (offsetToNextOccurrence < 0)
                offsetToNextOccurrence += 7;
            return current.AddDays(offsetToNextOccurrence);
        }
    }
