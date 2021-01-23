    public void RefreshOrders()
    {
      // Lock any fields you want to lock during the update process
      // Display some kind of waiting or progress bar
      if (!bkgdWrkGrid.IsBusy)
        bkgdWrkGrid.RunWorkerAsync();
    }
    private void bkgdWrkGrid_DoWork(object sender, DoWorkEventArgs e)
    {
      using (var grdBus = UnityInstanceProvider.GetInstance<IPfGridsBusiness>())
        e.Result = grdBus.LoadOpenOrders());  // Get data in background thread
    }
    private void bkgdWrkGrid_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (e.Error == null)  // Check for errors
      {
        gridOrders.DataSource = (List<OpenOrdersProxy>)e.Result;
      }
      else
      {
        // Show the error to the user
      }
      // Hide the waiting indicator
      // Unlock the fields
    }
