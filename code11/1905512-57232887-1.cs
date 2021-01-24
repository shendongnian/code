    Color lvPanelsItemCurrentBackColor = Color.FromArgb(58, 188, 58);
    Color lvPanelsItemSelectedBackColor = Color.FromArgb(48, 48, 48);
    Color lvPanelsItemBackColor = Color.FromArgb(28,28,28);
    Color lvPanelsItemForeColor = Color.White;
    private void lvPanels_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        var lView = sender as ListView;
        TextFormatFlags flags = GetTextAlignment(lView, e.ColumnIndex);
        Color itemBackColor = lvPanelsItemBackColor;
        Rectangle itemRect = e.Bounds;
        itemRect.Inflate(-2, -2);
        e.DrawBackground();
        if (e.Item.Selected || e.Item.Focused) {
            itemBackColor = e.Item.Focused ? lvPanelsItemCurrentBackColor : lvPanelsItemSelectedBackColor;
        }
        using (SolidBrush bkgrBrush = new SolidBrush(itemBackColor)) {
            e.Graphics.FillRectangle(bkgrBrush, itemRect);
        }
        TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, lvPanelsItemForeColor, flags);
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
