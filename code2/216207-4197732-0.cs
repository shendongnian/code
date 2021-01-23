      public class MyTimer : System.Timers.Timer
      {
        ElapsedEventHandler elapsed;
    
        public bool IsElapsedEventRunning { get; set; }
    
        //
        // Accept the ElapsedEventHandler in the constructor since the Elapsed property
        // is not virtual so it cannot be overridden.
        //
        public MyTimer(double interval, ElapsedEventHandler elapsed)
        {
          IsElapsedEventRunning = false;
          this.Interval = interval;
          // Save the ElapsedEventHandler
          this.elapsed = elapsed;
          // Set the base Timer's Elapsed event property to MY OWN ElapsedEventHandler
          Elapsed += new ElapsedEventHandler(MyTimer_Elapsed);
        }
    
        //
        // When base timer fires Elapsed event, my ElapsedEventHandler will be called.
        // Inside, set IsElapsedEventRunning = true, then call the user's event handler.
        // When finished, set IsElapsedEventRunning = false
        //
        void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
          //
          // Warning!  Not thread safe!  Not reentrant!
          //
          System.Diagnostics.Debug.WriteLine("MyTimer.IsElapsedEventRunning = {0}", IsElapsedEventRunning);
    
          IsElapsedEventRunning = true;
    
          // Is Invoke ok here or is BeginInvoke/EndInvoke required?
          elapsed.Invoke(sender, e);
    
          IsElapsedEventRunning = false;
    
          System.Diagnostics.Debug.WriteLine("MyTimer.IsElapsedEventRunning = {0}", IsElapsedEventRunning);
        }
    
      }
