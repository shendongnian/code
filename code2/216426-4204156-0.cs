    while (true)
    {
      Trace.Write("Starting ProcessQueue")
      stateTimer.Enabled = false;
      DateTime start = DateTime.Now;
    
      // do the work
    
      // check if timer should be restarted, and for how long
      TimeSpan workTime = DateTime.Now - start;
      double seconds = workTime.TotalSeconds;
      if (seconds > 30)
      {
        // do the work again
        continue;
      }
      else
      {
         // Restart timer to pop at the appropriate time from now
         stateTimer.Interval = 30 - seconds;
         stateTimer.Enabled = true;
         break;
      }
    }
