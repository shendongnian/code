    private void OnFormCloseing(object sender, FormClosingEventArgs e)
    {
        string reason = string.Empty;
        switch (e.CloseReason)
        {
            case CloseReason.UserClosing:
                reason = "Manual EXIT";
                break;
    
            case CloseReason.WindowsShutDown:
                reason = "Shutdown received";
                break;
        }
        Program.Log.InfoFormat(reason + " at {0}", DateTime.Now);
        CleanUp();
    }
    private void toolStripMenuItemExit_Click(object sender, EventArgs e)
    {
        this.Close(); //this is the main form
    }
