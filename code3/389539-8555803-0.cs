    public Form1()
    {
        InitializeComponent();
        backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
        backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
        backgroundWorker2.DoWork += new DoWorkEventHandler(backgroundWorker2_DoWork);
        backgroundWorker2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker2_RunWorkerCompleted);
        
        backgroundWorker1.RunWorkerAsync();
    }
    void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        Text = (string)e.Result;
    }
    void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
    {
        e.Result = (string)e.Argument;
    }
    void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        string s = (string)e.Result;
        backgroundWorker2.RunWorkerAsync(s);
    }
    void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        e.Result = "a";
    }
