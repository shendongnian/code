    public class MajorMinorTimer
    {
      public MajorMinorTimer
        (
          int parMinorTimerInterval_sec,
          int parMinorTicksPerMajorTick,
          Action<int> parMinorTickAction,
          Action parMajorTickAction,
          Func<bool> parShouldStopFunc
         )
      {
        myMinorTimerInterval_sec = parMinorTimerInterval_sec;
        myMinorTicksPerMajorTick = parMinorTicksPerMajorTick;
        myMinorTickAction = parMinorTickAction;
        myMajorTickAction = parMajorTickAction;
        myShouldStopFunc = parShouldStopFunc;
      }
    
      private Action<int> myMinorTickAction;
      private Action myMajorTickAction;
      private Func<bool> myShouldStopFunc;
      
      private void myBackingTimer_OnTick()
      {
        ++myMinorTickCount;
        int TicksRemaining = myMinorTickCount - MinorTicksPerMajorTick;
        if (TicksRemaining == 0)
          myMajorTickAction();
        else
          myMinorTickAction(TicksRemaining * MinorTickInterval_sec);
        
        bool Cancel = myShouldStopFunc();
        if (TicksRemaining == 0)
          myMinorTickCount = 0;
        if (Cancel)
          Stop();
      }
    }
