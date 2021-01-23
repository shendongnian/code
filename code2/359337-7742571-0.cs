    class MyForm
    {
      private BackgroundWorker _backgroundWorker;
    
      public Myform()
      {
        _backgroundWorker = new BackgroundWorker();
        _backgroundWorker.DoWork += CheckVersion;
        _backgroundWorker.RunWorkerCompleted += CheckVersionCompleted;
    
        // Show animation
        // Start the background work
        _backgroundWorker.DoWork();
      }
      
      private void CheckVersion()
      {
        // do background work here
      }
    
      private CheckVersionCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
        // hide animation
        // do stuff that should happen when the background work is done
      }
    }
