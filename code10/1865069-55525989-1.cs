    Color listViewSelectionColor = Color.Orange;
    protected void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        ListView lView = sender as ListView;
        TextFormatFlags flags = GetTextAlignment(lView, 0);
        if (e.Item.Selected) {
            using (SolidBrush bkgrBrush = new SolidBrush(listViewSelectionColor)) {
                e.Graphics.FillRectangle(bkgrBrush, e.Bounds);
            }
            if (lView.View == View.Details) return;
            Rectangle bounds = (lView.View == View.List)
                             ? new Rectangle(new Point(e.Bounds.X + 2, e.Bounds.Y), e.Bounds.Size)
                             : e.Bounds;
            TextRenderer.DrawText(e.Graphics, e.Item.Text, e.Item.Font, bounds, lView.BackColor, flags);
            if (lView.View == View.Tile && e.Item.SubItems.Count > 1)
            {
                var subItem = e.Item.SubItems[1];
                flags = GetTextAlignment(lView, 1);
                TextRenderer.DrawText(e.Graphics, subItem.Text, subItem.Font, e.Bounds, SystemColors.GrayText, flags);
            }
        }
        else { e.DrawDefault = true; }
    }
    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        ListView lView = sender as ListView;
        if (e.Item.Selected)
        {
            using (SolidBrush bkgrBrush = new SolidBrush(listViewSelectionColor))
            {
                TextFormatFlags flags = GetTextAlignment(lView, e.ColumnIndex);
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, lView.BackColor, flags);
            }
        }
        else { e.DrawDefault = true; }
    }
    protected void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        e.DrawDefault = true;
    }
    private TextFormatFlags GetTextAlignment(ListView lstView, int colIndex)
    {
        TextFormatFlags flags = (lstView.View == View.Tile)
            ? (colIndex == 0) ? TextFormatFlags.Default : TextFormatFlags.Bottom
            : TextFormatFlags.VerticalCenter;
        if (lstView.View == View.Details || lstView.View == View.Tile)
            flags |= TextFormatFlags.LeftAndRightPadding;
        if (lstView.View == View.List)
            flags = TextFormatFlags.NoPadding;
        switch (lstView.Columns[colIndex].TextAlign)
        {
            case HorizontalAlignment.Left:
                flags |= TextFormatFlags.Left;
                break;
            case HorizontalAlignment.Right:
                flags |= TextFormatFlags.Right;
                break;
            case HorizontalAlignment.Center:
                flags |= TextFormatFlags.HorizontalCenter;
                break;
        }
        return (flags | TextFormatFlags.NoPrefix);
    }
