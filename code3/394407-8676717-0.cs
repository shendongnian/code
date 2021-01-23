    timer.Interval = 1000; 
    timer.Tick += new EventHandler(TimerEventProcessor);
    timer.Start(); 
............
     private static void TimerEventProcessor(Object myObject,
                                                EventArgs myEventArgs) 
      {
           if(this.Opacity < 1)
             this.Opacity += .1;
           else
               timer.Stop(); 
      }
