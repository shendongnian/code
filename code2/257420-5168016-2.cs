    // Current selection
    private Rectangle _cropRectangle;
    // Starting point
    private Point _cropStart;
    // Dragging flag
    private bool _isDragging;
    private void pBox_MouseDown(object sender, MouseEventArgs e)
    {
        _cropRectangle = new Rectangle(e.X, e.Y, 0, 0);
        _isDragging = true;
    }
    private void pBox_MouseUp(object sender, MouseEventArgs e)
    {
        _isDragging = false;
    }
    private void pBox_MouseMove(object sender, MouseEventArgs e)
    {
        if (!_isDragging)
            return;
        _cropRectangle = new Rectangle(Math.Min(_cropStart.X, e.X),
                                       Math.Min(_cropStart.Y, e.Y),
                                       Math.Abs(e.X - _cropStart.X),
                                       Math.Abs(e.Y - _cropStart.Y));
        pBox.Invalidate();
    }
    private void pBox_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.DrawRectangle(Pens.Red, _cropRectangle);
    }
