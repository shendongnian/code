    private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        // GUI
        if (FScannerThread_Running)
        {
            FScannerThread_Running = false;
            if (!FScannerThread.Join(1000)) // Give the thread 1 sec to stop
            {
                FScanner.Abort();
            }    
        }
    }
