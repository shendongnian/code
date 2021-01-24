    public Bitmap ScrollableControlToBitmap(ScrollableControl canvas, bool includeHidden)
    {
        canvas.AutoScrollPosition = new Point(0, 0);
        if (includeHidden) {
            canvas.SuspendLayout();
            foreach (Control child in canvas.Controls) {
                child.Visible = true;
            }
            canvas.ResumeLayout(true);
        }
        Size containerSize = canvas.PreferredSize;
        var bitmap = new Bitmap(containerSize.Width, containerSize.Height, PixelFormat.Format32bppArgb);
        bitmap.SetResolution(this.DeviceDpi, this.DeviceDpi);
        using (var g = Graphics.FromImage(bitmap)) {
            g.Clear(canvas.BackColor);
        }
        for (int i = canvas.Controls.Count - 1; i >= 0; i--) {
            var child = canvas.Controls[i];
            if (child.Visible) {
                child.DrawToBitmap(bitmap, child.Bounds);
                if (child.HasChildren) {
                    DrawNestedControls(child, canvas, bitmap, child.Bounds);
                }
            }
        }
        return bitmap;
    }
    private void DrawNestedControls(Control parent, Control outerContainer, Bitmap bitmap, Rectangle parentBounds)
    {
        for (int i = parent.Controls.Count - 1; i >= 0; i--) {
            var ctl = parent.Controls[i];
            var clipBounds = Rectangle.Intersect(new Rectangle(Point.Empty, parentBounds.Size), ctl.Bounds);
            var bounds = outerContainer.RectangleToClient(parent.RectangleToScreen(clipBounds));
            ctl.DrawToBitmap(bitmap, bounds);
            if (ctl.HasChildren) {
                DrawNestedControls(ctl, outerContainer, bitmap, clipBounds);
            }
        }
    }
