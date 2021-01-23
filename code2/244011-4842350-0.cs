    double value = 12345.6789;
    Console.WriteLine(value.ToString("C", CultureInfo.CurrentCulture));
    
    Console.WriteLine(value.ToString("C3", CultureInfo.CurrentCulture));
    
    Console.WriteLine(value.ToString("C3", CultureInfo.CreateSpecificCulture("da-DK")));
    // The example displays the following output on a system whose
    // current culture is English (United States):
    //       $12,345.68
    //       $12,345.679
    //       kr 12.345,679
