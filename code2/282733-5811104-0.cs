    for (int i = 0; i < 5; ++i)
    {
        var tick = new System.Threading.Timer(TimerTick, i, 3000, 3000);
        list.Add(tick);
    }
