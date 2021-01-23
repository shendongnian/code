    private bool _canClose;
    public void Stop()
    {
        if (!_backgroundWorker.IsBusy)
        {
            _timer.Enabled = false;
            // Don't let the user do anything in the form until the background worker finishes
            this.IsEnabled = false;
            _label.Text = "Waiting for the process to finish";
            _canClose = false; 
        }
     }
    private void _backgroundWorker_RunWorkerCompleted(object sender,
        RunWorkerCompletedEventArgs e)
    {
        DoSomethingElse();
        // Allow the user to close the form
        this.IsEnabled = true;
        _canClose = true;
    }
    private void MainWindow_Closing(object sender, CancelEventArgs e)
    {
        e.Cancel = !_canClose;
    }
