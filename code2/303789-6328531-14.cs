    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
      contextMenuStrip1.Tag = (sender as ContextMenuStrip).SourceControl;
    }
    ....
    private object GetSourceControl(object Sender)
    {
      if (Sender as ContextMenuStrip != null)
      {
        return ContextMenuStrip.SourceControl;
      }
      var item = Sender as ToolStripItem;
      // move to root item
      while (item.OwnerItem != null)
      {
        item = item.OwnerItem;
      }
      // we have root item now, so lets take ContextMenuStrip object
      var menuObject = item.Owner as ContextMenuStrip;
      if (menuObject != null)
      {
        return menuObject.Tag;
      }
      return null;
    }
