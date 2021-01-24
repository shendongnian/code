    Color listViewSelectionColor = Color.Orange;
    protected void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        ListView lView = sender as ListView;
        if (lView.View == View.Details) return;
        TextFormatFlags flags = GetTextAlignment(lView, 0);
        Color itemColor = e.Item.ForeColor;
        if (e.Item.Selected) {
            using (SolidBrush bkgrBrush = new SolidBrush(listViewSelectionColor)) {
                e.Graphics.FillRectangle(bkgrBrush, e.Bounds);
            }
            itemColor = e.Item.BackColor;
        }
        else {
            e.DrawBackground();
        }
        TextRenderer.DrawText(e.Graphics, e.Item.Text, e.Item.Font, e.Bounds, itemColor, flags);
        if (lView.View == View.Tile && e.Item.SubItems.Count > 1)
        {
            var subItem = e.Item.SubItems[1];
            flags = GetTextAlignment(lView, 1);
            TextRenderer.DrawText(e.Graphics, subItem.Text, subItem.Font, e.Bounds, SystemColors.GrayText, flags);
        }
    }
    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        ListView lView = sender as ListView;
        TextFormatFlags flags = GetTextAlignment(lView, e.ColumnIndex);
        Color itemColor = e.Item.ForeColor;
        if (e.Item.Selected) {
            if (e.ColumnIndex == 0 || lView.FullRowSelect) {
                using (SolidBrush bkgrBrush = new SolidBrush(listViewSelectionColor)) {
                    e.Graphics.FillRectangle(bkgrBrush, e.Bounds);
                }
                itemColor = e.Item.BackColor;
            }
        }
        else  {
            e.DrawBackground();
        }
        TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, itemColor, flags);
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
        flags |= TextFormatFlags.LeftAndRightPadding | TextFormatFlags.NoPrefix;
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
        return flags;
    }
