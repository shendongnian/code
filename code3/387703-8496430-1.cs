    using System.Timers;
    
    void Main()
    {
        Timer t = new Timer();
        t.Interval = 0.5; //In seconds here
        t.AutoReset = true; //Stops it from repeating
        t.Elapsed += new ElapsedEventHandler(TimerElapsed);
        t.Start();
    }
    
    void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine("Hello, world!");
    }
