    var day = DateTime.Now; // today
    Console.WriteLine($"Today is {day.DayOfWeek}");
    int meeting = 21; // meeting in 21 days
    var meetingDay = day.AddDays(meeting);
    Console.WriteLine($"The meeting is on {meetingDay.DayOfWeek}");
    Console.Read();
