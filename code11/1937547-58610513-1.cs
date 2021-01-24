    // m is minutes, M is months
    var startDate = DateTime.ParseExact
      (Console.ReadLine(), "d.M.yyyy", CultureInfo.InvariantCulture);
    // m is minutes, M is months
    var endDate = DateTime.ParseExact(
      Console.ReadLine(), "d.M.yyyy", CultureInfo.InvariantCulture);
    var holidaysCount = 0;
    //DONE: Asssign date back: date = date.AddDays(1)
    for (var date = startDate; date <= endDate; date = date.AddDays(1))
    {
        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
        {
            holidaysCount++;
        }
    }
