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
        SizeF dpi = SizeF.Empty;
        using (var g = control.FindForm().CreateGraphics()) {
            dpi = new SizeF(g.DpiX, g.DpiY);
        };
        var bitmap = new Bitmap(containerSize.Width, containerSize.Height, PixelFormat.Format32bppArgb);
        bitmap.SetResolution(dpi.Width, dpi.Height);
        control.DrawToBitmap(bitmap, new Rectangle(0, 0, noScrollBarsArea.Width, noScrollBarsArea.Height));
        for (int i = control.Controls.Count - 1; i >= 0; i--) {
            var child = control.Controls[i];
            if (child.Visible) child.DrawToBitmap(bitmap, child.Bounds);
        }
        return bitmap;
    }
