    List<DateTime> dates = new List<DateTime>
    {
        new DateTime(2019, 12, 24),
        new DateTime(2019, 12, 25),
        new DateTime(2019, 12, 26),
        new DateTime(2020, 01, 04),
        new DateTime(2020, 01, 05),
        new DateTime(2020, 01, 10),
    };
    var initial = dates[0];
    var contiguous = dates.TakeWhile((date, i) => date == initial.AddDays(i)).ToList();
