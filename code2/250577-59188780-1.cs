    DateTime from = new DateTime(1990, 1, 1, 6, 30, 0);  // 7:30 AM
    DateTime to = new DateTime(1990, 1, 1, 13, 30, 0);   // 1:30 PM
    TimeSpan rangeStart = new TimeSpan(9, 0, 0);  // 9 AM
    TimeSpan rangeEnd = new TimeSpan(17, 0, 0);   // 5 PM
    // Results in 270 (4.5 hours)
    int minutes = GlobalHelpers.GetMinutesInRange(from, to, rangeStart, rangeEnd);
