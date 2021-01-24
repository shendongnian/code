    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Create new tab
        TabPage tp = new TabPage("Test");
        tabControl1.TabPages.Add(tp);
        // Add control into the tab
        TextBox tb = new TextBox();
        tb.Dock = DockStyle.Fill;
        tb.Multiline = true;
        tp.Controls.Add(tb);
        this.tabControl1.SelectedTab = this.tabControl1.TabPages[1];
    }
