    DateTime latestDate = new DateTime(2011, 3, 1); // note the new start date
    int noOfYears = 1; // could vary
    int shift = 1; // could vary
    
    Dictionary<DateTime, DateTime> dateRanges = new Dictionary<DateTime, DateTime>();
    for (var currentDate = latestDate.AddYears(noOfYears * -1); currentDate <= latestDate; currentDate = currentDate.AddMonths(shift))
    {
        dateRanges.Add(currentDate.AddYears(noOfYears *= -1).AddDays(-1), currentDate.AddDays(-1));
    }
