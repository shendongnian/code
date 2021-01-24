    TimeSpan flightTimeSpan = startWorkDay + timeSpan;
    DateTime flightDateTime = new DateTime(flightTimeSpan.Ticks);
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(flightDateTime.ToString("hh:mm tt"));
    }
