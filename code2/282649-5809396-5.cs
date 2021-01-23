    private bool wasMouseOver;
    private bool isMouseOver;
    public bool IsMouseOver { get { return isMouseOver; } }
    private void CheckMousePosition()
    {
        var mousePos = this.PointToClient(MousePosition);
        wasMouseOver = isMouseOver;
        isMouseOver = this.ClientRectangle.Contains(mousePos);
        if (isMouseOver != wasMouseOver)
            this.Invalidate(invalidateChildren: true);
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        CheckMousePosition();
        base.OnMouseMove(e);
    }
