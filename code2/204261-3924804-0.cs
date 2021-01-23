    ManualResetEvent _busy = new ManualResetEvent(false);
    
    private void btnCompleteAuto_Click(object sender, EventArgs e)
    {
        if (!backgroundWorker.IsBusy)
        {
            _busy.Set();
            btnAutoCompleteAuto.Text = "Pause";
            backgroundWorker.RunWorkerAsync();
        }
        else
        {
            _busy.Reset();
            btnAutoCompleteAuto.Text = "Resume";
        }
        
        btnStop.Enabled = true;
    }
    
    private void btnStop_Click(object sender, EventArgs e)
    {
        _busy.Set();
        backgroundWorker.CancelAsync();
    }
    
    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        // for (something)
        // {
        
            _busy.WaitOne();
            
            if (backgroundWorker.CancellationPending)
            {
                return;
            }
            
            // Do your work here.
            
        // }
    }
    
    private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        _busy.Reset();
        btnAutoCompleteAuto.Text = "Start";
        btnStop.Enabled = false;
    }
