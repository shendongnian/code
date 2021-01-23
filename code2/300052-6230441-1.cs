    static void Main(string[] args)
    {
        // Create a timer that polls once every 5 seconds
        var timer = new System.Threading.Timer(TimerProc, null, 5000, 5000);
        Console.WriteLine("Polling every 5 seconds.");
        Console.WriteLine("Press Enter when done:");
        Console.ReadLine();
        timer.Dispose();
    }
    static int TickCount = 0;
    static void TimerProc(object state)
    {
        ++TickCount;
        Console.WriteLine("tick {0}", TickCount);
    }
