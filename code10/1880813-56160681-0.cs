    private void Form1_Load(object sender, EventArgs e)
    {
        Timer1 = new System.Timers.Timer(10*1000); 
        Timer1.Elapsed += TimedEvent;
        TimedEvent();
    }
