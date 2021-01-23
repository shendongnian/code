    private void DoWork(object sender, DoWorkEventArgs e){
      foreach( ... )
      {
        //do some work
        if( myBackgroundWorker.CancellationPending )
        {
          return;
        }
      }
    }
