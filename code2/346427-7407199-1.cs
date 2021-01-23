    var daysOfWeek = new List<DayOfWeek> {
        DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday
    };
    DateTime date = daysOfWeek.NthDayOfMonthFrom(2011, 6, 3));
    Assert.Equal(date, new DateTime(2011, 6, 6));
