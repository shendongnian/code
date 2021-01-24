    public Bitmap ScrollableControlToBitmap(ScrollableControl control)
    {
        control.AutoScrollPosition = new Point(0, 0);
        int scrollBarWidth = SystemInformation.VerticalScrollBarWidth;
        Size containerSize = control.PreferredSize;
        Size noScrollBars = new Size(control.ClientSize.Width - scrollBarWidth, control.ClientSize.Height - scrollBarWidth);
        Rectangle clientRect = new Rectangle(Point.Empty, containerSize);
        var bitmap = new Bitmap(containerSize.Width, containerSize.Height, PixelFormat.Format32bppArgb);
        control.DrawToBitmap(bitmap, new Rectangle(0, 0, noScrollBars.Width, noScrollBars.Height));
        foreach (Control child in control.Controls)
        {
            child.DrawToBitmap(bitmap, child.Bounds);
        }
        return bitmap;
    }
