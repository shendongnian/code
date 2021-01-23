    void PrepareTimers() {
        var timer1 = new Timer();
        timer1.Interval = 5000;
        timer1.Elapsed += (sn, ea) => { TimerAction(100); };
        timer1.Start();
    
        var timer2 = new Timer();
        timer2.Interval = 5000;
        timer2.Elapsed += (sn, ea) => { TimerAction(103); };
        timer2.Start();
    
        // etc
    }
    
