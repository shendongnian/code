    // Elapsed event handler calls our other method
    private static void CreateOrderTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        // Not sure what the string argument represents, or how it should be set
        MoveToProcessed("some string");
    }
    // We can assign the event handler above when creating the Timer:
    protected override void OnStart(string[] args)
    {
        var createOrderTimer = new System.Timers.Timer
        {
            Interval = TimeSpan.FromMinutes(15).TotalMilliseconds,
            AutoReset = true
        };
        createOrderTimer.Elapsed += CreateOrderTimer_Elapsed;
        createOrderTimer.Start();
    }
