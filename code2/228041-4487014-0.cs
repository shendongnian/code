    void BeginCacheCandidates()
    {
        textBox1.Text = "Indexing...";
        textBox1.Enabled = false;
        backgroundWorker1.ReportProgress += new ProgressChangedEventHandler(handleProgress)
        backgroundWorker1.RunWorkerAsync();
    }
    
    void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        //prime the cache
        backgroundWorker1.ReportProgress(<some int>, <text to update>);
        CacheCandidates(candidatesCacheFileName);
    }
    void handleProgress(object sender, ProgressChangedEventArgs e)
    { 
        ... 
        textBox1.Text = e.UserState as String; 
        ... 
    }
    
