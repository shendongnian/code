    int weekNumber = 2;
    DateTime seekingDate = new DateTime(DateTime.Now.Year, 1, 1);
    while (seekingDate.DayOfWeek != DayOfWeek.Wednesday)
        seekingDate = seekingDate.AddDays(1);
    seekingDate.AddDays(7 * (weekNumber - 1));
