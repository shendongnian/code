    private void ListViewDrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        //toggle colors if the item is highlighted 
        if (e.Item.Selected && e.Item.ListView.Focused)
        {
            e.SubItem.BackColor = SystemColors.Highlight;
            e.SubItem.ForeColor = e.Item.ListView.BackColor;
        }
        else if (e.Item.Selected && !e.Item.ListView.Focused)
        {
            e.SubItem.BackColor = SystemColors.Control;
            e.SubItem.ForeColor = e.Item.ListView.ForeColor;
        }
        else
        {
            e.SubItem.BackColor = e.Item.ListView.BackColor;
            e.SubItem.ForeColor = e.Item.ListView.ForeColor;
        }
        // Draw the standard header background.
        e.DrawBackground();
            
        //add a 2 pixel buffer the match default behavior
        Rectangle rec = new Rectangle(e.Bounds.X + 2, e.Bounds.Y+2, e.Bounds.Width - 4, e.Bounds.Height-4);
        //TODO  Confirm combination of TextFormatFlags.EndEllipsis and TextFormatFlags.ExpandTabs works on all systems.  MSDN claims they're exclusive but on Win7-64 they work.
        TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis | TextFormatFlags.ExpandTabs | TextFormatFlags.SingleLine;
        //If a different tabstop than the default is needed, will have to p/invoke DrawTextEx from win32.
        TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.ListView.Font, rec, e.SubItem.ForeColor, flags);
    }
