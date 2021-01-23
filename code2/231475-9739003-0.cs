    private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
    {
        contextMenuStrip1.Tag = ((ContextMenuStrip)sender).OwnerItem;
    }
    private void ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ToolStripMenuItem senderItem = (ToolStripMenuItem)sender;
        var ownerItem = (ToolStripMenuItem)((ContextMenuStrip)senderItem.Owner).Tag;
    }
