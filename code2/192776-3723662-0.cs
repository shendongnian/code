    public DispatcherTimer myDispatcherTimer = new DispatcherTimer();
    
    private void ViewerTab_MouseLeave(object sender, MouseEventArgs e)
    {
        myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
        myDispatcherTimer.Tick += new EventHandler(functiontocall);
        myDispatcherTimer.Start();
    }
    
    public void functiontocall(object o, EventArgs sender)
    {
        // do something here
    
        myDispatcherTimer.Stop();
    }
    
    private void ViewerTab_MouseEnter(object sender, MouseEventArgs e)
    {
        myDispatcherTimer.Stop();
    }
