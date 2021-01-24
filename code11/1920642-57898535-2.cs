    var sw = new Stopwatch();
    var ticksPerFiveSeconds = TimeSpan.FromSeconds(5).Ticks;
    sw.Start();
    var p = new DateTime(1995, 12, 25, 12, 00, 00);
    var end = new DateTime(2005, 12, 25, 12, 00, 00);
    var size = (int)((end - p).TotalSeconds / 5 + 1);
    // preallocate array.
    var times = new DateTime[size];
    int i = 0;
    while ( p <= end )
    {
        times[i++] = p;
        p = p.AddTicks(ticksPerFiveSeconds);
    }
    sw.Stop();
    Console.WriteLine($"{(decimal)sw.ElapsedMilliseconds/1000M} {times.Length} {times.Last()}");
