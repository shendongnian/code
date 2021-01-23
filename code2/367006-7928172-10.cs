    var today = DateTime.Today;
    var daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);
    var dates = Enumerable.Range(1, daysInMonth)
                                .Select(n => new DateTime(today.Year, today.Month, n))
                                .Where(date => date.DayOfWeek != DayOfWeek.Sunday)
                                .SkipWhile(date => date.DayOfWeek != DayOfWeek.Monday)
                                .TakeWhile(date => date.DayOfWeek != DayOfWeek.Monday || (date.DayOfWeek == DayOfWeek.Monday && daysInMonth - date.Day > 7))
                                .ToArray();
