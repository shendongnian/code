    private void Form1_Load(object sender, EventArgs e)
    {
        if (Properties.Settings.Default.DPIAware)
            toolStripLabel1.Text = "DPI-awareness is enabled. Restart to disable DPI-awareness.";
        else
            toolStripLabel1.Text = "DPI-awareness is disabled. Restart to enable DPI-awareness.";
    }
    private void toolStripLabel1_Click(object sender, EventArgs e)
    {
        Properties.Settings.Default.DPIAware = !Properties.Settings.Default.DPIAware;
        Properties.Settings.Default.Save();
        Application.Restart();
    }
