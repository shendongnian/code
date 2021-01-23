    System.Timers.Timer tmr;
    void InitTimer(){
        tmr = new System.Timers.Timer();
        tmr.Interval = 300;
        tmr.AutoReset = false;
        tmr.Elapsed += OnElapsed;
    }
    void OnElapsed( object sender, System.Timers.ElapsedEventArgs e )
    {
        backgroundWorking();
        // let timer start ticking
        tmr.Enabled = true;
	}
