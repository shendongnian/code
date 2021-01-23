    var dt = new DateTime(2010, 10, 8, 18, 0, 0);
    
    // this line will return 18 h
    Console.WriteLine(dt.ToLocalizedLongTimeString(CultureInfo.GetCultureInfo("fr-CA")));
    // this line returns 6:00:00 PM
    Console.WriteLine(dt.ToLocalizedLongTimeString());
    
    var dt2 = new DateTime(2010, 10, 8, 18, 45, 0);
    // this line will return 18 h 45
    Console.WriteLine(dt2.ToLocalizedLongTimeString(CultureInfo.GetCultureInfo("fr-CA")));
    // this line returns 6:45:00 PM
    Console.WriteLine(dt2.ToLocalizedLongTimeString());
