    private Timer _delayTimer;
    
    public Constructor()
    {
    ...
      _delayTimer = new Timer(300);
      _delayTimer.Elapsed += DelayTimer_Elapsed;
    }
    
    private void Canvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
      if (e.ChangedButton == MouseButton.Left && e.ClickCount == 1)
      {
        _delayTimer.Start();
      }
      else if (e.ClickCount == 2)
      {
        e.Handled = true;
        _delayTimer.Stop();
      }
      else
      {
         _delayTimer.Stop();
      }
    }
    
    private void DelayTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
     // Do your thing here for Single Left Click.
    }
