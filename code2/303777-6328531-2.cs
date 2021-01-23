    /// <summary>
    /// Gets controls for context menu
    /// </summary>
    /// <param name="Sender">Sender object from menu event handler</param>
    /// <returns></returns>
    private object GetSourceControl(Object Sender)
    {
      // ContextMenuStrip sended?
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
        return menuObject.SourceControl;
      }
      return null;
    }
