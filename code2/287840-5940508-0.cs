    System.Timers.Timer myTimer;
    void Main()
    {
        myTimer = new System.Timers.Timer(1000);
        myTimer.Elapsed += new System.Timers.ElapsedEventHandler(myTimer_Elapsed);
        myTimer.Start();
    }
    void myTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        myTimer.Stop();
        // process event
        myTimer.Start();
    }
