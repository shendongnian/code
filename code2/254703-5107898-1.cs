    DateTime now = DateTime.Now;
    DateTime tomorrow = now.AddDays(1);
    DateTime yesterday = now.AddDays(-1);
    DateTime nextWeek = now.Add(TimeSpan.FromDays(7));
    DateTime dayAfterNext = now.Add(TimeSpan.FromDays(1) + TimeSpan.FromDays(1));
    
    TimeSpan twoDays = TimeSpan.FromDays(1) + TimeSpan.FromDays(1);
    TimeSpan oneMinute = TimeSpan.FromMinutes(2) - TimeSpan.FromMinutes(1);
    DateTime oneMinuteFromNow = now.Add(oneMinute);
