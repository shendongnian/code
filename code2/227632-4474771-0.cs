    public MyUserControl()
    {
        _resizeTimer.Tick += _resizeTimer_Tick;
    }
    
    DispatcherTimer _resizeTimer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 1500), IsEnabled = false };
    
    private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        _resizeTimer.IsEnabled = true;
        _resizeTimer.Stop();
        _resizeTimer.Start();
    }
    
    void _resizeTimer_Tick(object sender, EventArgs e)
    {
        _resizeTimer.IsEnabled = false;    
        //Do end of resize processing
    }
