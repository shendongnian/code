    public void RefreshInventory()
    {
        // Lock any fields you want to lock during the update process
        // Display some kind of waiting or progress bar
        if (!bkgdWrkInventory.IsBusy)
            bkgdWrkInventory.RunWorkerAsync();
    }
    private void bkgdWrkInventory_DoWork(object sender, DoWorkEventArgs e)
    {
        var db = new AcidDBDataContext();
        e.Result = db.GetProducts.ToList();
    }
    private void bkgdWrkInventory_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error == null)  // Check for errors
        {
            dgvInventory.DataSource = (List<Product>)e.Result;
        }
        else
        {
            // Show the error to the user
        }
        // Hide the waiting indicator
        // Unlock the fields
    }
