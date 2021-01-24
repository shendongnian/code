     public static void Main()
    {
        System.Timers.Timer myTimer = new System.Timers.Timer();
        myTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        myTimer.Interval = 5000;
        myTimer.Enabled = true;
    
        Console.WriteLine("Press \"q\" to quit the sample.");
        while(Console.Read() != "q");
    }
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
     {
                   Console.WriteLine("Hello World!");
                   Background = Brushes.Coral;
                   Background = Brushes.AliceBlue;
                   Background = Brushes.DarkRed;
                   Background = Brushes.Red;
                   Background = Brushes.Blue;
                   Background = Brushes.Aquamarine;
     }
 
