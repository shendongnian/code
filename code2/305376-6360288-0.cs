    Form1 f2 = null;
        
    private void addRecordsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (f2 == null)
        {
             f2 = new Form1();
             f2.MdiParent = this;
             f2.button1.Enabled = true;
        }
        f2.Show();
    }
        
    private void updateRecordsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (f2 == null)
        {
            f2.MdiParent = this;
            f2.button2.Enabled = true;
            f2.button1.Enabled = false;
        }
        f2.Show();
    }
