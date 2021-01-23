    private void item_Click(object sender, EventArgs e)
    {
        ToolStripMenuItem item = sender as ToolStripMenuItem;
        if (item != null)
        {
            int index = ContextMenuStrip.Items.IndexOf(commentMenuItem);
        }
    }
