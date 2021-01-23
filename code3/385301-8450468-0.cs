    Point MouseLocation;
    
    private void MouseMove(object sender, MouseEventArgs e)
    {
        MouseLocation = e.Location;
        Invalidate();
    }
    
    private void Paint(object sender, PaintEventArgs e)
    {
        g.DrawLine(Pens.Black, new Point(0, MouseLocation.Y), new Point(Width, MouseLocation.Y));
        g.DrawLine(Pens.Black, new Point(MouseLocation.X, 0), new Point(MouseLocation.X, Height));
    }
