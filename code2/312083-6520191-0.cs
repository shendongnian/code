    LocalDate start = new LocalDate(2010, 4, 15);
    LocalDate end = new LocalDate(2010, 6, 19);
    Period period = Period.Between(start, end); // Defaults to Year/Month/Day
    Console.WriteLine(period.Months); // 2
    Console.WriteLine(period.Days); // 4
