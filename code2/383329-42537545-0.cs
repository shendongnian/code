    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (MessageBox.Show("Are you sure that you would like to cancel the installer?", "Cancel Installer", MessageBoxButtons.YesNo) == DialogResult.No)
        {
            e.Cancel = true;
        }
    }
