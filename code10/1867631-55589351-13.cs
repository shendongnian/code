    System.DateTime date1 = new System.DateTime(1996, 6, 3, 22, 15, 0);
    System.DateTime date2 = new System.DateTime(1996, 12, 6, 13, 2, 0);
    System.DateTime date3 = new System.DateTime(1996, 10, 12, 8, 42, 0);
    
    // diff1 gets 185 days, 14 hours, and 47 minutes.
    System.TimeSpan diff1 = date2.Subtract(date1);
    // diff2 gets 55 days 4 hours and 20 minutes.
    System.TimeSpan diff2 = date2 - date3;
