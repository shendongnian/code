    BackgroundWorker _backgroundWorker;
    private BackgroundWorker CreateBackgroundWorker()
    {
        var bw = new BackgroundWorker();
        bw.WorkerSupportsCancellation = true;
        bw.DoWork += _backgroundWorker_DoWork;
        bw.RunWorkerCompleted += new  _backgroundWorker_RunWorkerCompleted;
        return bw.
    }
    private void LoadHtmlAndParse(string foobar)
    {
        //Cancel whatever it is you're doing!
        if (_backgroundWorer != null)
        {
            _backgroundWorker.CancelAsync();
        }
        _backgroundWorker = CreateBackgroundWorker();
    
        //And start doing this immediately!
        _backgroundWorker.RunWorkerAsync(foobar);
    }
    
    //you no longer need this because the value is being stored in e.Result
    //POCOClassFoo foo = new POCOClassFoo();
    
    private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            //Error handling goes here.
        }
        else
        {
            if (e.Cancelled)
            {
                //handle cancels here.
            }
            {
                //This automagically sets the UI to the data.
                Foo.DataContext = (POCOClassFoo)e.Result;
            }
    }
    
    private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        //DOING THE HEAVY LIFTING HERE!
        e.Result = parseanddownloadresult()!
    }
