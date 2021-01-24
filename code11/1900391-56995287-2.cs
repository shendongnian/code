    List<DateTime> allMeetings = new List<DateTime>() {
        new DateTime(2019, 07, 7),
        new DateTime(2019, 07, 8),
        new DateTime(2019, 07, 9),
        new DateTime(2019, 09, 17),
        new DateTime(2019, 07, 10),
        new DateTime(2019, 07, 11),
        new DateTime(2019, 07, 14),
        new DateTime(2019, 07, 12),
        new DateTime(2019, 07, 13),
    };
    IEnumerable<DateTime> meetings = allMeetings.Where(x => x.Date.CompareTo(DateTime.Today) > 0).OrderBy(x => x.Date);
    foreach (DateTime meeting in meetings) {
        Console.WriteLine(meeting);
    }
