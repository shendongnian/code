    BackgroundWorker bg2 = new BackgroundWorker();
    bg2.DoWork +=new DoWorkEventHandler(bg2_DoWork);
    .ProgressChanged += new ProgressChangedEventHandler(bg2_ProgressChanged)
    bg2.RunWorkerAsync();
    
    void bg2_DoWork(object sender, DoWorkEventArgs e)
        {
    
            while (bg1.IsBusy)
                worker.ReportProgress(totalProgress);
        }
    private void bg2_ProgressChanged(object sender,
                ProgressChangedEventArgs e)
            {
                DrawWellPlate.pbar.Value = e.ProgressPercentage;
            }
