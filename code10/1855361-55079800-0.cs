    private void ListView1_MouseMove(object sender, MouseEventArgs e)
    {
        ListViewItem item = listView1.GetItemAt(e.X, e.Y);
        if (LastHoveredItem != null)
        {
            ListViewItem item2 = LastHoveredItem;
            LastHoveredItem = null;
            listView1.Invalidate(item2.Bounds);
        }
        if (item != null)
        {
            LastHoveredItem = item;
            listView1.Invalidate(item.Bounds);
        }
        else
        {
            LastHoveredItem = null;
        }
    }
    private void ListView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        bool hot = e.Item.Bounds.Contains(listView1.PointToClient(Cursor.Position));
        if (LastHoveredItem == e.Item)
        {
            e.Graphics.FillRectangle(Brushes.Green, e.Bounds);
        }
    }
