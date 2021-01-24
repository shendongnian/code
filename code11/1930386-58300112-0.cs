     private void DoWorkButton_Click(object sender, RoutedEventArgs e)
       {
             testProgressBar.Visibility = Visibility.Visible;
             ProgressTextblock.Visibility = Visibility.Visible;
             BackgroundWorker worker = new BackgroundWorker();
             worker.WorkerReportsProgress = true; 
             worker.DoWork += worker_doWork;                         
             worker.ProgressChanged += worker_ProgressChanged;
             worker.RunWorkerCompleted += worker_RunWorkerCompleted;
             worker.RunWorkerAsync();
    }
