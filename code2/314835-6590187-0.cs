    private void chkBackup_CheckChanged(object sender, EventArgs e)
    {
    	Properties.Settings.Default.Backup = chkBackup.Checked;
    	Properties.Settings.Default.Save();
    }
