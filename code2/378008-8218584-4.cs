    //  DispatcherTimer setup
    dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
    dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
    dispatcherTimer.Interval = new TimeSpan(0,0,1);
    dispatcherTimer.Start();
            
    //  System.Windows.Threading.DispatcherTimer.Tick handler
    //
    //  Updates the current seconds display and calls
    //  InvalidateRequerySuggested on the CommandManager to force 
    //  the Command to raise the CanExecuteChanged event.
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        // Updating the Label which displays the current second
        lblSeconds.Content = DateTime.Now.Second;
    
        // Forcing the CommandManager to raise the RequerySuggested event
        CommandManager.InvalidateRequerySuggested();
    }
     
