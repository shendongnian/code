    DateTime start = new DateTime(2010, 01, 01, 21, 00, 00);
    DateTime end = new DateTime(2010, 10, 01, 14, 00, 00);
    
    // Shift start date's hour to 7 and same for end date
    // These will be added after doing calculation:
    int startAdjustmentMinutes = (start.Hour - 7) * 60;
    int endAdjustmentMinutes = (end.Hour - 7) * 60;
    
    // We can do some basic
    // mathematical calculation to find weekdays count:
    // divide by 7 multiply by 5 gives complete weeks weekdays
    // and adding remainder gives the all weekdays:
    int weekdaysCount = (((int)((end.Date - start.Date).Days / 7) * 5) 
              + ((end.Date - start.Date).Days % 7));
    // so we can multiply it by minutes between 7am to 7 pm
    int minutes = weekdaysCount * (12 * 60);
    
    // after adding adjustment we have the result:
    int result = minutes + startAdjustmentMinutes + endAdjustmentMinutes;
