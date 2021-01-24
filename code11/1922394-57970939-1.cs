    public Form1()
    {
        InitializeComponent();
        timer = new System.Timers.Timer();
        timer.Interval = 30000;
        timer.Enabled = true;
        timer.Elapsed += (s, e) => {backgroundWorker1.RunWorkerAsync();}; 
    }
    ...
    private void button1_Click(object sender, EventArgs e) 
    {  
        backgroundWorker1.RunWorkerAsync();
    }
