    // Probably make this a static readonly field
    TimeSpan earliest = new TimeSpan(20, 0, 0); 
    DateTime now = DateTime.Now;
    TimeSpan currentTime = now.TimeOfDay;
    if (currentTime >= earliest)
    {
        DateTime newDateTime = now.Date.AddDays(1).AddHours(1);
    }
