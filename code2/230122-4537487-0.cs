    const long ticksPerSecond = 10000000;
    const long intervalSize = 10;
    DateTime start = new DateTime(2010, 12, 27, 9, 0, 0);
    long ticks = DateTime.Now.Ticks - start.Ticks;
    long interval = ticks / (ticksPerSecond * intervalSize);
    Console.WriteLine(interval);
