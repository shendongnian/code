    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        BackgroundWorker worker = new BackgroundWorker();
        worker.WorkerReportsProgress = true;
        worker.DoWork += worker_DoWork;
        worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        worker.ProgressChanged += worker_ProgressChanged;
    
        pbStatus.Visibility = Visibility.Visible;
        worker.RunWorkerAsync();
    }
    
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
    
        getAll();
        //for (int i = 0; i < 100; i++)
        //{
        //    (sender as BackgroundWorker).ReportProgress(i);
        //    Thread.Sleep(100);
        //}
    }
    
    void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        pbStatus.Visibility = Visibility.Hidden;
    
    }
    
    void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        pbStatus.Value = e.ProgressPercentage;
    }
