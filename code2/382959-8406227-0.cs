    private void ListViewDrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        // Draw the standard header background.
        e.DrawBackground();
        //add a 2 pixel buffer the match default behavior
        Rectangle rec = new Rectangle(e.Bounds.X + 2, e.Bounds.Y+2, e.Bounds.Width - 4, e.Bounds.Height-4);
        //TODO  Confirm combination of TextFormatFlags.EndEllipsis and TextFormatFlags.ExpandTabs works on all systems.  MSDN claims they're exclusive but on Win7-64 they work.
        TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis | TextFormatFlags.ExpandTabs | TextFormatFlags.SingleLine;
        //If a different tabstop than the default is needed, will have to p/invoke DrawTextEx from win32.
        TextRenderer.DrawText(e.Graphics, e.SubItem.Text, lsvFamilies.Font, rec, lsvFamilies.ForeColor, flags);
    }
