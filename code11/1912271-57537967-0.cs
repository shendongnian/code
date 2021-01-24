    System.Timers.Timer t = new System.Timers.Timer(10000);
    t.Elapsed += OnTimedEvent;
    t.AutoReset = true;
    t.Enabled = true;
    
    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
      Device.BeginInvokeOnMainThread( () => {
        test.Text = i;
        i++;
      });
    }
