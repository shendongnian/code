           System.Timers.Timer timer;
           //Set Timer
           timer = new Sytem.Timers.Timer();
           timer.Tick += new EventHandler(timer_tick);
           timer.Interval = 10000; //10000 ms = 10 seconds
           timer.Enabled = true;
    
    
           public void timer_tick(object source, EventArgs e)
           {
                 //Here what would you like to do every 10000 ms
           }
