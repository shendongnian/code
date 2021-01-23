    private Point lastPos;
    protected override void OnMouseMove(MouseEventArgs e) {
        if (e.Button == MouseButtons.Left) {
            int dx = e.X - lastPos.X;
            int dy = e.Y - lastPos.Y;
            Location = new Point(Left + dx, Top + dy);
            // NOTE: do NOT update lastPos, the relative mouse position changed
        }
        base.OnMouseMove(e);
    }
    protected override void OnMouseDown(MouseEventArgs e) {
        if (e.Button == MouseButtons.Left) {
            lastPos = e.Location;
            BringToFront();
            this.Capture = true;
        }
        base.OnMouseDown(e);
    }
    protected override void OnMouseUp(MouseEventArgs e) {
        this.Capture = false;
        base.OnMouseUp(e);
    }
