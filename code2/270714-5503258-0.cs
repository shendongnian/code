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
        // Do some work
        System.Threading.Thread.Sleep(5000);
        // Update progress (50% done)
        mWorker.ReportProgress(50);
        // Check if the code was aborted
        if (mWorker.CancellationPending) {
            e.Cancel = true;
            return;
        }
        // Do some more work
        System.Threading.Thread.Sleep(5000);
        mWorker.ReportProgress(100);
        // Instead of this 0-50-100 thing you can put your loop here.
        // Just remember to call mWorker.ReportProgress to update the progress bar.
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
        if (e.Cancel) {
            // show the message box that the task has been canceled
        }
    }
    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
        if (mWorker != null) {
            if (mWorker.IsBusy) {
                mWorker.CancelAsync();
            }
        }
    }
