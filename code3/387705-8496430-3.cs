    using System.Timers;
    
    void Main()
    {
        Timer t = new Timer();
        t.Interval = 500; // In milliseconds
        t.AutoReset = false; // Stops it from repeating
        t.Elapsed += new ElapsedEventHandler(TimerElapsed);
        t.Start();
    }
    
    void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine("Hello, world!");
    }
