    private static DateTime NextDateTimeByDayOfWeek(DateTime target, List<DayOfWeek> validDaysOfWeek)
        {
            return Enumerable.Range(1, 7)
                .Select(n => target.AddDays(n))
                .First(date => validDaysOfWeek.Contains(date.DayOfWeek));
        }
