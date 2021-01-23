    var start = DateTime.Today.Add(new TimeSpan(7, 30, 0));
    var times = Enumerable.Range(0, 48)
                          .Select(offset => start.Add(TimeSpan.FromMinutes(30 * offset)));
    foreach (var time in times)
    {
        string timeValue = time.ToString("hh:mmtt");
        // ...
    }
