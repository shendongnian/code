    void ShowBackGroundWorkerActive(bool active)
    {
        // give user indication about active backgroundworker, for instance show ajax loader gif
        this.GifBackgroundWorkerActive.Visible = active;
    }
    bool IsBackGroundWorkerActive => this.GifBackgroundWorkerActive.Visible;
    void StartBackgroundWorking()
    {
         if (this.IsBackgroundWorkerActive) return; // already active
 
         // do some preparations:
         this.ShowBackgroundWorkerActive(true);
       
         // start the backgroundworker
         this.backgroundWorker.RunWorkerAsync();
    }
    void CancelBackgroundWorking()
    {
        this.backgroundWorker.CancelAsync();
    }
