    private BackgroundWorker m_worker;
    
    private void StartWorking()
    {
        if (m_worker != null)
            throw new InvalidOperationException("The worker is already doing something");
    
        m_worker = new BackgroundWorker();
        m_worker.CanRaiseEvents = true;
        m_worker.WorkerReportsProgress = true;
    
        m_worker.ProgressChanged += worker_ProgressChanged;
        m_worker.DoWork += worker_Work;
        m_worker.RunWorkerCompleted += worker_Completed;
    }
    
    private void worker_Work(object sender, DoWorkEventArgs args)
    {
        m_worker.ReportProgress(0, "Getting the data...");
        var data = DataGetter.GetData();
    
        m_worker.ReportProgress(33, "Processing the data...");
        var processedData = DataProcessor.Process(data);
        
        // if this interacts with the GUI, this should be run in the GUI thread.
        // use InvokeRequired/BeginInvoke, or change so this question is asked
        // in the Completed handler. it's safe to interact with the GUI there,
        // and in the ProgressChanged handler.
        m_worker.ReportProgress(67, "Waiting for user decision...");
        var userDecision = DialogService.AskUserAbout(processedData);
    
        m_worker.ReportProgress(100, "Finished.");
        args.Result = userDecision;
    }
    
    private void worker_ProgressChanged(object sender, ProgressChangedEventArgs args)
    {
        // this gets passed down from the m_worker.ReportProgress() call
        int percent = args.ProgressPercentage;
        string progressMessage = (string)args.UserState;
        
        // show the progress somewhere. you can interact with the GUI safely here.
    }
    
    private void worker_Completed(object sender, RunWorkerCompletedEventArgs args)
    {
        if (args.Error != null)
        {
            // handle the error
        }
        else if (args.Cancelled)
        {
            // handle the cancellation
        }
        else
        {
            // the work is finished! the result is in args.Result
        }
    }
