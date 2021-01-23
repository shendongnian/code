    myTimer.Interval = 5000;//5s
    private void eventArrived(object sender, EventArrivedEventArgs e)
    {
       if(!myTimer.Enabled) //if timer not running
          myTimer.Start();
    }
    private void myTimer_Tick(object sender, System.EventArgs e)
    {
       //enumerate statuses every 5s
    }
