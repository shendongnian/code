    new List<dynamic> {
        new { ScheduledTime = "6/7/2019 11:45 PM" },
        new { ScheduledTime = "6/7/2019 10:45 PM" },
        new { ScheduledTime = "6/6/2019 9:45 PM" }
    }
    .OrderByDescending(a => DateTime.Parse(a.ScheduledTime).Date)
    .ThenBy(a => DateTime.Parse(a.ScheduledTime).TimeOfDay);
