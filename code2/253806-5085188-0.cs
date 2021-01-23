    DateTime start = DateTime.Today.Add(new TimeSpan(7, 30, 0)); 
    
    var clock = from offset in Enumerable.Range(0, 48)
                     select start.AddMinutes(30 * offset);
    foreach (DateTime time in clock)
    {
        string timeValue = time.ToString("hh:mmtt");
    }
