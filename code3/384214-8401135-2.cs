    try
    {
        DispatcherTimer dispatcherTimer = new  System.Windows.Threading.DispatcherTimer();
        dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
        dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        dispatcherTimer.Start();
        return CurrentDateTime;
    }
