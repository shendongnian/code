    private void MenuViewDetails_Click(object sender, EventArgs e)
    {
         // Try to cast the sender to a ToolStripItem
         ToolStripItem menuItem = sender as ToolStripItem;
         if (menuItem != null)
         {
            // Retrieve the ContextMenuStrip that owns this ToolStripItem
            ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
            if (owner != null)
            {
               // Get the control that is displaying this context menu
               Control sourceControl = owner.SourceControl;
            }
         }
     }
