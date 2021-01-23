    DateTime original = new DateTime(year, month, day, 8, 0, 0);
    DateTime updated = original.Add(new TimeSpan(5,0,0));
    DateTime original = new DateTime(year, month, day, 5, 0, 0);
    DateTime updated = original.Add(new TimeSpan(-2,0,0));
    DateTime original = new DateTime(year, month, day, 5, 30, 0);
    DateTime updated = original.Add(new TimeSpan(0,45,0));
