    System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
    
    myTimer.Tick += new EventHandler(TimerEventProcessor);
    myTimer.Interval = 5000;//This is in milli seconds
    myTimer.Start();
    
    
    private void TimerEventProcessor(Object myObject,
                                                EventArgs myEventArgs) {
    {
      //Your code 
    }
