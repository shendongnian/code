    static System.Timers.Timer _timer = new System.Timers.Timer();
    static void Main()
    {
        _timer.Interval = 5000;
        _timer.Elapsed  += _timer_Tick;
        _timer.Enabled = true;
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey(); // Block until you hit a key to prevent shutdown
    }
    static void _timer_Tick(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine("Timer Elapsed!");
    }
