    public Form1()
    {
        InitializeComponent();
        timer = new System.Timers.Timer();
        timer.Interval = 30000;
        timer.Enabled = true;
        timer.Elapsed += timer_Elapsed; // not button1_Click
    }
    ...
    private void timer_Elapsed(object sender, ElapsedEventArgs e)
    {            
        backgroundWorker1.RunWorkerAsync();                      
    }
    private void button1_Click(object sender, EventArgs e) 
    {  
        backgroundWorker1.RunWorkerAsync();
    }
