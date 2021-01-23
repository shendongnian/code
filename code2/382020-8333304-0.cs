        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
    
    public Form1()
    {
        InitializeComponent();
    
        myTimer.Interval = 1000;
        myTimer.Tick += new EventHandler(myTimer_Tick);
        myTimer.Start();
    
    }
    
    void myTimer_Tick(object sender, EventArgs e)
    {
        myTimer.Stop();
        //Do stuff when it ticks.
    }
