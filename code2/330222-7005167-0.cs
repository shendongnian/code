    // a simple delegate to report the amount of time remaining 
    // prior to the expiration of the major tick interval; zero
    // indicates that this major tick has elapsed.
    public delegate void delegateMajorMinorTimerTick
      (
        int TimeRemaining_sec, ref bool CancelTimer
      );
    
    // you could use milliseconds for the interval settings to get
    // better granularity, or you could switch to setting the major
    // interval instead, however that approach would require a bit 
    // more checking to make sure the control has sane settings.
    public class MajorMinorTimer
    {
      // this sets the interval in seconds between the
      // "minor" ticks used for intermediate processing
      // these are the "inner" intervals of the timer
      private int myMinorTickInterval_sec;
      public int MinorTickInterval_sec
      {
        get { return myMinorTickInterval_sec; }  
      } 
    
      // this sets the number of minor ticks between the
      // expiration of the major interval of the timer.
      // the "outer" interval of the timer
      private int myMinorTicksPerMajorTick;
      public int MinorTicksPerMajorTick
      {
        get { return myMinorTicksPerMajorTick; }
      }
    
      public MajorMinorTimer
        (
          int parMinorTickInterval_sec,
          int parMinorTicksPerMajorTick
        )
      {
        MinorTickInterval_sec = parMinorTickInterval_sec;
        MinorTicksPerMajorTick = parMinorTicksPerMajorTick;
      } 
    
      private DispatcherTimer myBackingTimer; 
    
      private int myMinorTickCount;
      public void Start()
      {
        // reset the minor tick count and start the dispatcher
        // timer with some reasonable defaults.
        myMinorTickCount = 0;
        myBackingTimer = 
          new DispatcherTimer
            (
              TimeSpan.FromSeconds(MinorTickInterval_sec),
              DispatcherPriority.Normal,
              new EventHandler(myBackingTimer_Tick),
              Dispatcher.CurrentDispatcher
            );
    
        myBackingTimer.Start();
      }
    
      public event delegateMajorMinorTimerTick onTick;
      private bool FireMajorMinorTimerTick(int TimeRemaining_sec)
      {
        // allows the timer sink to cancel the timer after this
        // call; just as an idea, also could be handled with a
        // call to Stop() during the event, but this 
        // simplifies handling a bit (at least to my tastes)
        bool CancelTimer = false; 
        if (onTick != null)
          onTick(TimeRemaining_sec, ref CancelTimer);
        return CancelTimer;
      }
    
      private void myBackingTimer_Tick(object Sender, EventArgs e)
      {
        // since we are using a DispatchTimer with settings that should
        // do not suggest the possibility of synchronization issues,
        // we do not provide further thread safety.  this could be
        // accomplished in the future if necessary with a lock() call or
        // Mutex, among other methods.
        ++myMinorTickCount;
        int TicksRemaining = myMinorTickCount - MinorTicksPerMajorTick;
        bool Cancel = 
          FireMajorMinorTimerTick(TicksRemaining * MinorTickInterval_sec);
        if (TicksRemaining == 0)
          myMinorTickCount = 0;
        if (Cancel)
          Stop();
      }
    
      public void Stop()
      {
         myBackingTimer.Stop();
      }
    }
