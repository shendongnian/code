    private void lvUsers_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        if (e.ColumnIndex == 5)
        {
            e.DrawDefault = false;
            Rectangle bounds = e.Bounds;
            double pct = ...;
            Rectangle fill = new Rectangle(
                bounds.Left, bounds.Top,
                (int)(pct * bounds.Width), bounds.Height);
            using (LinearGradientBrush lg = ...)
            {
                e.Graphics.FillRectangle(lg, fill);
            }
            e.Graphics.DrawRectangle(Pens.Black, bounds);
           ...
        }
        else
        {
            e.DrawDefault = true;
        }
    }
