    var today = DateTime.Today;
    
    var dates = Enumerable.Range(1, DateTime.DaysInMonth(today.Year, today.Month))
    							.Select(n => new DateTime(today.Year, today.Month, n))
    							.Where(date => date.DayOfWeek != DayOfWeek.Sunday)
    							.ToArray();
