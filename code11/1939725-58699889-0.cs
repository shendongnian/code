    private void OnElapsedTime(object source, ElapsedEventArgs e)
    {
        WriteToFile("Service is recall at " + DateTime.Now);
        timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
        timer.Interval = TimeSpan.FromMinutes(30).TotalMilliseconds; //number in milisecinds  
        timer.Enabled = true;
        if (!backgroundWorker1.IsBusy())
        {
            backgroundWorker1.RunWorkerAsync();
        }
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        global::MFTSearchService.Search.SearchStart();
    }
