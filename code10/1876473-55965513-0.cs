    List<DateTime> dt = new List<DateTime>();
    var avDateTime = DateTime.Now;
    for (int i = DateTime.Now.Hour; i <= 23; i++)
    {
        avDateTime = avDateTime.Now.AddHours(1);
        dt.Add(avDateTime );
    }
