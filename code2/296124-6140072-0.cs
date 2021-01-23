    DateTime today = DateTime.Today;
    DateTime secondFriday = 
         Enumerable.Range(8, 7)
                   .Select(item => new DateTime(today.Year, today.Month, item))
                   .Where(date => date.DayOfWeek == DayOfWeek.Friday)
                   .Single();
