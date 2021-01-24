    private bool isChangedFromCode = false;
    
    private void dtpStartDate_Enter(object sender, EventArgs e)
    {
        isChangedFromCode = true;
        // Reports cannot be generated later than today.
        dtpStartDate.MaxDate = DateTime.Now.Date.AddDays(-1.0);
        isChangedFromCode = false;
    }
    private void dtpStartDate_ValueChanged(object sender, EventArgs e)
    {
        if(isChangedFromCode) { return; }
        // rest of the code here...
    }
