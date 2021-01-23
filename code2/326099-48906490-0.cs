    DateTime checkIn = new DateTime(_checkInYear, _checkInMonth, _checkInDay);
    DateTime checkOut = new DateTime(_checkOutYear, _checkOutMonth, _checkOutDay);
    List<DateTime> allDates = new List<DateTime> ();
    for (DateTime date = checkIn; date <= checkOut; date = date.AddDays(1))
        allDates.Add(date);
