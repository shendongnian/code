    private void radioButton_CheckedChanged(object sender, EventArgs e)
    {
        // ...
        if (backgroundWorker1.IsBusy)
        {
            backgroundWorker1.CancelAsync();
            addJobToQueue();   // Don't wait here, just store what needs to be executed.
        } else {
            backgroundWorker1.RunWorkerAsync();
        } 
    }
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Cancelled) {
            label1.Text = "Canceled";
        }
        else {
            label1.Text = "Complete";
        }
        // We've finished! See if there is more to do...
        if (thereIsAnotherJobInTheQueue())
        {
             startAnotherBackgroundWorkerTask();
        }
    }
