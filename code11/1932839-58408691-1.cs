    private void Form1_Load(object sender, EventArgs e)
    {    
        timer = new System.Timers.Timer();
        timer.Interval = 1000 * 60 * 5; //5 minutes
        timer.Elapsed += Timer_Elapsed;
        InitializeTimer(); //this method makes sure the timer starts at the correct time
    }
