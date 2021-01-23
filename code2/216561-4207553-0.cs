    private void dispTimer_Tick(object sender, EventArgs e) 
    {
      var uiDispatcher = Dispatcher.CurrentDispatcher;
      BackgroundWorker _worker = new BackgroundWorker(); 
      _worker.DoWork += (sender, e) =>
        uiDispatcher.BeginInvoke(new Action(() =>
        {
          PartialEmployees.Clear();
        }));
      _worker.RunWorkerAsync(); 
    } 
