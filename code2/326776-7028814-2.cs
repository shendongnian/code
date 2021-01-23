    private void BackgroundWorkerButton_Click(object sender, EventArgs eventArgs)
    {
        var operation = new SampleOperation();
        BackgroundWorkerButton.Enabled = false;
        BackgroundOperation(operation, (s, e) =>
            {
                BackgroundWorkerButton.Enabled = true;
            });
    }
    private void BackgroundOperation(ISteppedOperation operation, RunWorkerCompletedEventHandler runWorkerCompleted)
    {
        var backgroundWorker = new BackgroundWorker();
        backgroundWorker.RunWorkerCompleted += runWorkerCompleted;
        backgroundWorker.WorkerSupportsCancellation = true;
        backgroundWorker.WorkerReportsProgress = true;
        backgroundWorker.DoWork += new DoWorkEventHandler((s, e) =>
        {
            while (operation.MoveNext())
            {
                operation.ProcessCurrent();
                int percentProgress = (100 * operation.CurrentStep) / operation.StepCount;
                backgroundWorker.ReportProgress(percentProgress);
                if (backgroundWorker.CancellationPending) break;
            }
        });
        backgroundWorker.ProgressChanged += new ProgressChangedEventHandler((s, e) =>
        {
            var progressChangedEventArgs = e as ProgressChangedEventArgs;
            this.progressBar1.Value = progressChangedEventArgs.ProgressPercentage;
        });
        backgroundWorker.RunWorkerAsync();
    }
