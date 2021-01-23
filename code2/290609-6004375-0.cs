    public Form1()
    {
        InitializeComponent();
        backgroundWorker1.RunWorkerAsync();
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        for(var i = 0; i < 1000; i++)
        {
            var newElement = BuildMyElement(i);
            backgroundWorker1.ReportProgress(0, newElement);
        }
    }
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        var newElement = (MyType)e.UserState;
        listBox1.Items.Add(newElement);
    }
