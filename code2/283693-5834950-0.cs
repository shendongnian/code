      BackgroundWorker bg = new BackgroundWorker();
      bg.WorkerSupportsCancellation = true;
      bg.DoWork += backgroundWorker_DoWork;
      bg.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
            BackgroundWorker bw = sender as BackgroundWorker;
            List<object> args = (List<object>)e.Argument;
            var url = args[0];
            WebRequest request = WebRequest.Create(url);
            if (bw.CancellationPending)
            {
                e.Cancel = true;
            }
        }
      private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                StatusMessage = "Operation was cancelled.";
            }
        }
