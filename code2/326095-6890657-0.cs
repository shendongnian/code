    DateTime checkIn = new DateTime(_checkInYear, _checkInMonth, _checkInDay);
    DateTime checkOut = new DateTime(_checkOutYear, _checkOutMonth, _checkOutDay);
    TimeSpan span = checkOut - checkIn;
    List<DateTime> range = new List<DateTime>();
    for(int day = 0; day <= span.Days; day++) 
    {
        range.Add(checkIn.AddDays(day));
    }
