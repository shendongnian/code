     CultureInfo german = new CultureInfo("de-DE");
     DateTimeFormatInfo dtfi = german.DateTimeFormat;
     Console.WriteLine("Days of the week for the {0} culture:",
                        german.Name);
     for (int ctr = 0; ctr < dtfi.DayNames.Length; ctr++)
        Console.WriteLine("   {0,-12}{1}", dtfi.DayNames[ctr],
                          dtfi.DayNames[ctr] == dtfi.DayNames[(int)dtfi.FirstDayOfWeek] ? 
                                "(First Day of Week)" : "");  
