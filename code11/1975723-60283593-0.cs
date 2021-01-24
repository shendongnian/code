    static System.Timers.Timer _t = new System.Timers.Timer();
    
    void Init()
    {
        //Start a timer trigger every 300000 milliseconds = 5 minutes
         _t.Interval = 300000;
         _t.Elapsed += 5MinutesElapsed;
         _t.Enabled = true;
    }    
    public void 5MinutesElapsed()
    {
        //Do Something
    }
