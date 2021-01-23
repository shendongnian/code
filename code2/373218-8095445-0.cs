    public void SetProgressValue(int value)
    {
        if (this.ProgressBar.InvokeRequired)
        {
           this.BeginInvoke(new Action<int>(SetProgressValue), value);
           return;
        }
        this.ProgressBar.Value= value;
    }
