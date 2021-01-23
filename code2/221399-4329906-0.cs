    public static System.Timers.Timer timer = new System.Timers.Timer(60000); // This will raise the event every one minute.
    .
    .
    .
    
    timer.Enabled = true;
    timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
    .
    .
    .
    
    static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      // Do Your Stuff
    }
