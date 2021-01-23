    var startDate = new DateTime(checkInYear, checkInMonth, checkInDay);
    var endDate = new DateTime(checkOutYear, checkOutMonth, checkOutDay);
    var givenDate = startDate; 
    var datesInRange = new List<DateTime>(); 
    
    while (givenDate <= startDate)
    {
        datesInRange.Add(givenDate);
        givenDate = givenDate.AddDays(1);
    }
    // work with / return datesInRange
