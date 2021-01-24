    ownedForm.KeyPreview = true;
    ownedForm.KeyDown += OwnedForm_KeyDown;
    private void OwnedForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control)
        {
            foreach (ToolStripMenuItem menuItem in menu.Items)
            {
                foreach (ToolStripMenuItem item in menuItem.DropDownItems.OfType<ToolStripMenuItem>())
                {
                    if (item.ShortcutKeys == e.KeyData)
                    {
                        item.PerformClick();
                        return;
                    }
                }
            }
        }
    }
