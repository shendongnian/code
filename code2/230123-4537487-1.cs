    const long ticksPerSecond = 10000000;    // Number of ticks in a second
    const long intervalSize = 2;             // Size of an interval in seconds
    DateTime start = new DateTime(2010, 12, 27, 12, 33, 58);
    long ticks = DateTime.Now.Ticks - start.Ticks;
    long interval = 1 + ticks / (ticksPerSecond * intervalSize);
    Console.WriteLine(interval);
