    public Form1()
    {
        InitializeComponent();
        backgroundWorker1.DoWork += backgroundWorker1_DoWork;
        backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        backgroundWorker2.DoWork += backgroundWorker2_DoWork;
        backgroundWorker2.RunWorkerCompleted += backgroundWorker2_RunWorkerCompleted;
        
        backgroundWorker1.RunWorkerAsync();
    }
    void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        e.Result = "a";
    }
    void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        string s = (string)e.Result;
        backgroundWorker2.RunWorkerAsync(s);
    }
    void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
    {
        e.Result = (string)e.Argument;
    }
    void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        Text = (string)e.Result;
    }
