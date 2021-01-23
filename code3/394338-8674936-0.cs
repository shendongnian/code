    public class TimerWrapper
    {
      public event EventHandler Elapsed;
      private System.Timers.Timer timer;
      private System.Threading.ManualResetEvent stopped;
      private object lockObject = new object();
      public TimerWrapper(double interval)
      {
        stopped = new System.Threading.ManualResetEvent(false);
        timer = new System.Timers.Timer(interval);
        timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        timer.Start();
      }
      void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
      {
        lock (lockObject)
        {
          timer.Stop();
          try
          {
            Elapsed(this, new EventArgs());
          }
          finally
          {
            if (!stopped.WaitOne(0)) timer.Start();
          }
        }
      }
      public void Start()
      {
        stopped.Reset();
        lock (lockObject)
        {
          timer.Start();
        }
      }
      public void Stop()
      {
        stopped.Set();
        lock (lockObject)
        {
          timer.Stop();
        }
      }
    }
