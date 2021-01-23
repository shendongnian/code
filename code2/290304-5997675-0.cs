    DateTime startTime = DateTime.Today.AddHours(9).AddMinutes(30);
    DateTime endTime = DateTime.Today.AddHours(12+4);
    DateTime now = DateTime.Now;
    if(startTime > now && endTime < now) {
        // do something
    }
