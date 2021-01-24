     public static void Main()
     {
         
          System.Timers.Timer myTimerCoral = new System.Timers.Timer();
          myTimerCoral.Elapsed += new ElapsedEventHandler(OnTimedEventCoral);
          myTimerCoral.Interval = 5000;
          myTimerCoral.Enabled = true;
         
          System.Timers.Timer myTimerAliceBlue = new System.Timers.Timer();
          myTimerAliceBlue.Elapsed += new ElapsedEventHandler(OnTimedEventAliceBlue);
          myTimerAliceBlue.Interval = 5000;
          myTimerAliceBlue.Enabled = true;
        ...
        Console.WriteLine("Press \"q\" to quit the sample.");
        while(Console.Read() != "q");
     }
     private static void OnTimedEventCoral(object source, ElapsedEventArgs e)
     {
                   Background = Brushes.Coral;
     }
     private static void OnTimedEventAliceBlue(object source, ElapsedEventArgs e)
     {
                   Background = Brushes.AliceBlue;
     }
     ...
