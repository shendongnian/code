    private void ProcessingStatusEventHandler(object sender, StatusEventArgs e)
    {
        try
        {
            if (e.State.Value == State.UPDATE_PROGRESS)
            {
                this.BeginInvoke((ProcessHelperDelegate)delegate
                {
                    this.progressBar.Value = e.PercentageComplete;
                }
            }
        }
        catch { }
    }
