    protected override void OnMouseEnter(EventArgs e)
    {
        var mousePos = this.PointToClient(MousePosition);
        if (this.ClientRectangle.Contains(mousePos))
        {
            this.Invalidate(invalidateChildren: true);
        }
        base.OnMouseEnter(e);
    }
    protected override void OnMouseLeave(EventArgs e)
    {
        var mousePos = this.PointToClient(MousePosition);
        if (!this.ClientRectangle.Contains(mousePos))
        {
            this.Invalidate(invalidateChildren: true);
        }
        base.OnMouseLeave(e);
    }
