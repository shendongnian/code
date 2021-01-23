            public int GetNoOfLeaveDays(DateTime fromDate, DateTime toDate, Boolean excludeWeekends, List<DateTime> excludeDates)
        {
            var count = 0;
            for (DateTime index = fromDate; index <= toDate; index = index.AddDays(1))
            {
                if (!excludeWeekends || index.DayOfWeek == DayOfWeek.Saturday || index.DayOfWeek == DayOfWeek.Sunday) continue;
                var excluded = excludeDates.Any(t => index.Date.CompareTo(t.Date) == 0);
                if (!excluded) count++;
            }
            return count;
        }
