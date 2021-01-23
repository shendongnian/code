    private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // First, handle the case where an exception was thrown.
        if (e.Error != null)
        {
            MessageBox.Show(e.Error.Message);
        }
        else if (e.Cancelled)
        {
            // Next, handle the case where the user canceled the operation.         
        }
    }
