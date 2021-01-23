    protected void InvalidateEx() {
        if (Parent != null) {
            Rectangle rc = new Rectangle(0, 0, this.ClientSize.Width - SystemInformation.VerticalScrollBarWidth, this.ClientSize.Height);
            rc = this.RectangleToScreen(rc);
            rc = Parent.RectangleToClient(rc);
            Parent.Invalidate(rc, false);
        }
    }
