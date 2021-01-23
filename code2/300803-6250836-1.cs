    private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!TerminatingApp)
        {
            e.Cancel = true;
            Hide();
        }
    }
    private void chiudiToolStripMenuItem_Click(object sender, EventArgs e)
    {
        TerminatingApp = true;
        trayIcon.Dispose();
        Application.Exit();
    }
