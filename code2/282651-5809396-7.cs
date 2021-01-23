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
    // then register this method to the mouse events
    EventHandler mouseHandler = (sender, e) => CheckMousePosition();
    MouseEnter += mouseHandler;
    MouseLeave += mouseHandler;
    MouseMove += (sender, e) => CheckMousePosition();
