    Console.WriteLine("Bitte Tag eingeben");
    int day = Convert.ToInt32(Console.ReadLine());
    
    Console.WriteLine("Bitte Monat eingeben");
    int month = Convert.ToInt32(Console.ReadLine());
    
    DateTime dt = new DateTime(2019, month, day);
    
    CultureInfo culture = CultureInfo.CurrentCulture;
    CalendarWeekRule cwr = culture.DateTimeFormat.CalendarWeekRule;
    DayOfWeek dow = culture.DateTimeFormat.FirstDayOfWeek;
    
    int weekOfYear = culture.Calendar.GetWeekOfYear(dt, cwr, dow);
