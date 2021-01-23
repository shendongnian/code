    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {
        ucAdmin ucA = new ucAdmin(); //ucAdmin is a user control u had created.
        ucA.Visible = true;
        ucA.Dock = DockStyle.Fill;
        this.pnlMain.Controls.Clear(); // pnlMain is the location u are going to display this user control.
        this.pnlMain.Controls.Add(ucA);
    }
