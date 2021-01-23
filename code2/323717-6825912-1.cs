    protected override void OnStart(string[] args)
    { 
            var timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(DoSomething);
            //do something every 30 seconds
            timer.Interval = TimeSpan.FromSeconds(30).TotalMilliseconds; 
            timer.Start();
    }
    private void DoSomething(object sender, ElapsedEventArgs e)
    {
        //Do your timed event here...
    }
