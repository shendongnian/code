    public void static Main()
    {
    	var bw = new BackgroundWorkder();
    	bw.DoWork += _worker_DoWork;
    	bw.RunWorkerCompleted += _worker_RunWorkerCompleted;
    	bw.ProgressChanged += _worker_ProgressChanged;
    	bw.WorkerReportsProgress = true;
    	bw.WorkerSupportsCancellation = false;
    
    	//START PROCESSING
    	bw.RunWorkerAsync(/*PASS FILE DATA*/);
    }
    
    private void _worker_DoWork(object sender, DoWorkEventArgs e)
    {
    	BackgroundWorker bw = sender as BackgroundWorker;
    	var data = e.Argument as /*DATA OBJECT YOU PASSED*/;
    
    	//PSEUDO CODE
    	foreach(var file in FILES)
    	{
    		zipFile;
    		//HERE YOU CAN REPORT PROGRESS
    		bw.ReportProgress(/*int percentProgress, object userState*/)
    	}
    }
    
    private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
    	// Just update progress bar with % complete or something
    }
    
    private void _worker_RunWorkerCompleted(object sender, 
                                   RunWorkerCompletedEventArgs e)
    {
    	if (e.Error != null)
    	{
    		//...
    	}
    	else
    	{
    		//......
    	}
    }
