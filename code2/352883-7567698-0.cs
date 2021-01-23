     int timerCount = 0;
-
    private void bckWrkSocket_DoWork(object sender, DoWorkEventArgs e)
    {
         timer.Tick += new EventHandler(TimerEventProcessor);
    
         // Sets the timer interval to 1 minute.
         timer.Interval = 60000;
         timer.Start();
    }
     
