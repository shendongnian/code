    private void ReInitialazeAll()
    {
        // Make sure we're running on the UI thread
        if (this.InvokeRequired)
        {
            BeginInvoke(new Action(ReInitialazeAll));
    
            return;
        }
    
        // Hide the progress bar
        this.ProgressBar.Visible = false;
    
        // ... execute UI-related code
    }
