    bool b = false;
    
    Stopwatch sw = Stopwatch.StartNew();
    for (int i = 0; i < int.MaxValue; ++i)
    {
        b = true;
    }
    sw.Stop();
    
    TimeSpan setNoCheckTime = sw.Elapsed;
    
    sw = Stopwatch.StartNew();
    for (int i = 0; i < int.MaxValue; ++i)
    {
        // This part will never assign, as b will always be true.
        if (!b)
        {
            b = true;
        }
    }
    sw.Stop();
    
    TimeSpan checkSetTime = sw.Elapsed;
    
    Console.WriteLine("Assignment: {0} ms", setNoCheckTime.TotalMilliseconds);
    Console.WriteLine("Read: {0} ms", checkSetTime.TotalMilliseconds);
