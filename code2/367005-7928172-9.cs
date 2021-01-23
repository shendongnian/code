    var today = DateTime.Today;
    var daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);
    var dates = Enumerable.Range(1, daysInMonth)
    							.Select(n => new DateTime(today.Year, today.Month, n))
    							.Where(date => date.DayOfWeek != DayOfWeek.Sunday)
    							.ToArray();
