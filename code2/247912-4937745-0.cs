    using System.Timers;
    
    public static void Main() {
        Timer t = new Timer();
        t.Elapsed += new ElapsedEventHandler(ActionWhenFinished);
        t.Interval = 10000;
        t.Start();
    }
    
    public static void ActionWhenFinished()
    {
        // cancel any action
    }
