    DateTime a = new DateTime(2010, 10, 30, 21, 58, 29);
    DateTime b = a + new TimeSpan(12, 5, 54, 24, 623);
    var minutes = from day in a.DaysInRangeUntil(b)
                  where !day.IsWeekendDay()
                  let start = Max(day.AddHours( 7), a)
                  let end   = Min(day.AddHours(19), b)
                  select (end - start).TotalMinutes;
    var result = minutes.Sum();
    // result == 6292.89
