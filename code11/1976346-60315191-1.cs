    public Form1()
    {
        InitializeComponent();
        //Init the worker here...
        worker.WorkerSupportsCancellation = true;
        worker.WorkerReportsProgress = true;
        worker.DoWork += Worker_DoWork;
        worker.ProgressChanged += Worker_ProgressChanged;
        worker.RunWorkerAsync(PText.Text);
        worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
    }
    private void Run_Click(object sender, RoutedEventArgs e)
    {
        //only run the worker here
        worker.RunWorkerAsync(PText.Text);       
    }
