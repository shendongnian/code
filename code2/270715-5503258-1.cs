    System.ComponentModel.BackgroundWorker mWorker;
    private void button1_Click(object sender, RoutedEventArgs e) {
        mWorker = new System.ComponentModel.BackgroundWorker();
        mWorker.DoWork +=new System.ComponentModel.DoWorkEventHandler(worker_DoWork);
        mWorker.ProgressChanged +=new System.ComponentModel.ProgressChangedEventHandler(worker_ProgressChanged);
        mWorker.WorkerReportsProgress = true;
        mWorker.WorkerSupportsCancellation = true;
        mWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        mWorker.RunWorkerAsync();
        // Don't do anything else here
    }
    private void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
        for (int i = 1; i < 100; i++) {
            mWorker.ReportProgress(i);
            // Do some part of the work
            System.Threading.Thread.Sleep(100);
            // Check if the user wants to abort
            if (mWorker.CancellationPending) {
                e.Cancel = true;
                return;
            }
        }
        mWorker.ReportProgress(100);  // Done
    }
    private void worker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e) {
        pbProcessing.Value = e.ProgressPercentage;
    }
    private void worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
        // Stop Progressbar updatation  
        Window1 w = new Window1();
        w.Browser.Navigate(new Uri("http://stackoverflow.com"));
        w.Show();
        // Check the result
        if (e.Cancelled) {
            // show the message box that the task has been canceled
        }
        // Reset Progress bar
        pbProcessing.Value = 0;
    }
    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
        if (mWorker != null) {
            if (mWorker.IsBusy) {
                mWorker.CancelAsync();
            }
        }
    }
