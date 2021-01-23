    DateTime dt1 = new DateTime(2009, 1, 1);// new DateTime(2009, 6, 1);
    DateTime dt2 = new DateTime(2010, 10, 27);// new DateTime(2011, 7, 18);
    if (dt1.Month < 4)
      dt1 = new DateTime(dt1.Year,1,1);
    else if (dt1.Month < 7)
      dt1 = new DateTime(dt1.Year,4,1);
    else if (dt1.Month < 10)
      dt1 = new DateTime(dt1.Year,7,1);
    else
      dt1 = new DateTime(dt1.Year,10,1);
    if (dt2.Month < 4)
       dt2 = new DateTime(dt2.Year, 3, DateTime.DaysInMonth(dt2.Year, 3)); 
    else if (dt2.Month < 7)
       dt2 = new DateTime(dt2.Year, 6, DateTime.DaysInMonth(dt2.Year, 6));
    else if (dt2.Month < 10)
       dt2 = new DateTime(dt2.Year, 9, DateTime.DaysInMonth(dt2.Year, 9));
    else
       dt2 = new DateTime(dt2.Year, 12, DateTime.DaysInMonth(dt2.Year, 12));
                                      
    TimeSpan ts = dt2 - dt1;
    int quarters = (int) ts.TotalDays/90;
    Console.WriteLine(quarters);
