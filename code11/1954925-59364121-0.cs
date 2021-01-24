    int durationOfSession = 60;
    int gapBetweenSessions = 30;
    DateTime start = DateTime.Today.AddHours(8);
    DateTime end = DateTime.Today.AddHours(18);
    for (DateTime appointment = start; appointment < end; appointment = appointment.AddMinutes(durationOfSession + gapBetweenSessions)) {
        Console.WriteLine(appointment.ToString("HH:mm"));
    }
