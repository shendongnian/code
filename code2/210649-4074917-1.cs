    public void RunWorkerAsync()
    {
        this.RunWorkerAsync(null);
    }
    
    public void RunWorkerAsync(object argument)
    {
        if (this.isRunning)
        {
            throw new InvalidOperationException(SR.GetString("BackgroundWorker_WorkerAlreadyRunning"));
        }
        this.isRunning = true;
        this.cancellationPending = false;
        this.asyncOperation = AsyncOperationManager.CreateOperation(null);
        // the important bit
        this.threadStart.BeginInvoke(argument, null, null);
    }
