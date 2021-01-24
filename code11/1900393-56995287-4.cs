    class Meeting {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
    List<Meeting> allMeetings = new List<Meeting>() {
        new Meeting{ Name = "1", Date = new DateTime(2019, 07, 7), Time = new TimeSpan(9, 15, 00) },
        new Meeting{ Name = "2", Date = new DateTime(2019, 07, 17), Time = new TimeSpan(9, 15, 00) },
        new Meeting{ Name = "3", Date = new DateTime(2019, 07, 17), Time = new TimeSpan(11, 15, 00) },
        new Meeting{ Name = "4", Date = new DateTime(2019, 07, 11), Time = new TimeSpan(11, 15, 00) },
        new Meeting{ Name = "5", Date = new DateTime(2019, 07, 12), Time = new TimeSpan(11, 15, 00) },
        new Meeting{ Name = "6", Date = new DateTime(2019, 07, 13), Time = new TimeSpan(11, 15, 00) },
        new Meeting{ Name = "7", Date = new DateTime(2019, 07, 14), Time = new TimeSpan(11, 15, 00) },
    };
    IEnumerable<Meeting> meetings = allMeetings.Where(x => x.Date.CompareTo(DateTime.Today) > 0).OrderBy(x => x.Date).ThenBy(x => x.Time);
    foreach (Meeting meeting in meetings) {
        Console.WriteLine($"{meeting.Name}\t{meeting.Date}\t{meeting.Time}");
    }
