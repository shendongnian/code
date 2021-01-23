    private void tabControl1_MouseDown(object sender, MouseEventArgs e)
    {
        var lastIndex = this.tabControl1.TabCount - 1;
        if (this.tabControl1.GetTabRect(lastIndex).Contains(e.Location))
        {
            this.tabControl1.TabPages.Insert(lastIndex, "New Tab");
            this.tabControl1.SelectedIndex = lastIndex;
        }
    }
