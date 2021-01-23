    System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
    
    public Form1()
    {
        myTimer.Interval = 1000;
        myTimer.Tick += new EventHandler(myTimer_Tick);
        myTimer.Start();
        //Do stuff. 
    }
    
    void myTimer_Tick(object sender, EventArgs e)
    {
        myTimer.Stop();
        //Do stuff when it ticks.
    }
