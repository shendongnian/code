    public Bitmap ScrollableControlToBitmap(ScrollableControl control)
    {
        control.AutoScrollPosition = new Point(0, 0);
        int scrollBarWidth = control.VerticalScroll.Visible 
                           ? SystemInformation.VerticalScrollBarWidth : 0;
        int scrollBarHeight = control.HorizontalScroll.Visible 
                            ? SystemInformation.HorizontalScrollBarHeight : 0;
        Size containerSize = control.PreferredSize;
        Size noScrollBarsArea = new Size(control.ClientSize.Width - scrollBarWidth, 
                                         control.ClientSize.Height - scrollBarWidth);
        var bitmap = new Bitmap(containerSize.Width, containerSize.Height, PixelFormat.Format32bppArgb);
        control.DrawToBitmap(bitmap, new Rectangle(0, 0, noScrollBarsArea.Width, noScrollBarsArea.Height));
        foreach (Control child in control.Controls)
        {
            child.DrawToBitmap(bitmap, child.Bounds);
        }
        return bitmap;
    }
