    bool IsBackGroundWorkerBusy => this.backgroundWorker.IsBusy;
    void StartBackgroundWork()
    {
        if (this.IsBackGroundWorkerbusy) return; // already started;
        this.DisplayBackgroundWorkerActive(); // for example, show an ajax loader 
        this.backgroundWorker.RunworkerAsync();
        // or if you want to start with parameters:
        MyParameters backgroundWorkerParameters = new MyParameters(...);
        this.backgroundWorker.RunworkerAsync(backgroundWorkerParameters);
       
    }
    void RequestCancelBackgroundWork()
    {
        this.DisplayBackgroundWorkerStopping();
        this.backgroundWorker.CancelAsync();
    }
