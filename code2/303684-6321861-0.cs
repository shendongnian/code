    BackgroundWorker backgroundWorker1= new backgroundWorker()
    private void InitializeBackgroundWorker()
    {
            backgroundWorker1.DoWork += 
                new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.WorkerSupportsCancellation = true;
    }
    
    private void backgroundWorker1_DoWork(object sender, 
            DoWorkEventArgs e)
    {   
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = YourWorkToDo();
    }
    public void Start()
    {
        backgroundWorker1.RunWorkerAsync()
    }
    public voic Cancel()
    {
        backgroundWorker1.CancelAsync();
    {
