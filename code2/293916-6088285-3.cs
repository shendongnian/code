    // Initialization
    BackgroundWorker bw = new BackgroundWorker();
    bw.DoWork += new DoWorkEventHandler(bw_DoWork);
    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
    
    // Start elaboration
    bw.RunWorkerAsync(objectArgument);
    
    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
       // do your work (we are in the background-thread)
       // when you have finished, set your results in the e.Result property
       // N.B. don't show anything because we are in the background-thread
    }
    
    void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
       // here we have finished the work (we are in the UI-thread)
       // result is set in e.Result property
       // N.B. check e.Error property before to get e.Result because
       //      if there's an error e.Result throws an exception
    }
