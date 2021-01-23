    HijriCalendar hijri = new HijriCalendar();
    DateTime firstDayInMonth = new DateTime(1433, 10, 11, hijri);
    Console.WriteLine(hijri.GetEra(firstDayInMonth)); // 1
    Console.WriteLine(hijri.GetYear(firstDayInMonth)); // 1433
    Console.WriteLine(hijri.GetMonth(firstDayInMonth)); // 10
    Console.WriteLine(hijri.GetDayOfMonth(firstDayInMonth)); // 11
