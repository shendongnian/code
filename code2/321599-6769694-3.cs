    private void tare_Click(object sender, EventArgs e)
    {
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        myTimer.Tick += new EventHandler(TimerEventProcessor);
        myTimer.Interval = 10;
        myTimer.Start();
    }
    void TimerEventProcessor(object sender, EventArgs e)
    {
        Get_Attitude();
    }
