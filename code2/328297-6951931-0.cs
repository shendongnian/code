    private void Form1_Load(object sender, EventArgs e)
    {
        label1.Text = string.Format("Value is: {0}", Properties.Settings.Default.SomeBool);
        blaBlubToolStripMenuItem.Checked = Properties.Settings.Default.SomeBool;
    }
