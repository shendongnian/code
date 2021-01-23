    public void chkPermission_CheckChanged(object sender, EventArgs e)
    {
        bool isChecked = chkPermission.Checked;
        if (this.user.HasPermission() == isChecked) { return; }
        // otherwise, we need to change some permissions!
    }
