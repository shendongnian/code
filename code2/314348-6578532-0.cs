    public void InitBackgroundWorker()
    {
        backgroundWorker.DoWork += YourLongRunningMethod;
        backgroundWorker.RunWorkerCompleted += UpdateTheWholeUi;
        backgroundWorker.WorkerSupportsCancellation = true; // optional
        // these are also optional
        backgroundWorker.WorkerReportsProgress = true;
        backgroundWorker.ProgressChanged += UpdateProgressBar;
    }
    // This could be in a button click, or simply on form load
    if (!backgroundWorker.IsBusy)
    {
        backgroundWorker.RunWorkerAsync(); // Start doing work on background thread
    }
    // ...
    private void YourLongRunningMethod(object sender, DoWorkEventArgs e)
    {
        var worker = sender as BackgroundWorker;
        if(worker != null)
        {
            // Do work here...
            // possibly in a loop (easier to do checks below if you do)
            // Optionally check (while doing work):
            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
                break; // If you were in a loop, you could break out of it here...
            }
            else
            {
                // Optionally update
                worker.ReportProgress(somePercentageAsInt);
            }
            e.Result = resultFromCalculations; // Supports any object type...
        }
    }
    private void UpdateProgressBar(object sender, ProgressChangedEventArgs e)
    {
        int percent = e.ProgressPercentage;
        // Todo: Update UI
    }
    private void UpdateTheWholeUi(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
            // Todo: Update UI
        }
        else if (e.Error != null)
        {
            string errorMessage = e.Error.Message;
            // Todo: Update UI
        }
        else
        {
            object result = e.Result;
            // Todo: Cast the result to the correct object type,
            //       and update the UI
        }
    }
