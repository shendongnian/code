    var userHasCancelled = false;
    while(!userHasCancelled && isExcelRunning())
    {
        var result = MessageBox.Show("Excel is still running. Please save your work and close Excel, and then click \"Retry\" button to continue with installation.", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
        if (result != DialogResult.Retry)
        {
             userHasCancelled = true;
        }
    }
    if (userHasCancelled)
    {
        //User cancelled...
    }
    else
    {
        //Continue.
    }
