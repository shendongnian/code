    private void SplitContainer_Paint(object sender, PaintEventArgs e)
    {
        var control = sender as SplitContainer;
        //paint the three dots'
        Point[] points = new Point[3];
        var w = control.Width;
        var h = control.Height;
        var d = control.SplitterDistance;
        var sW = control.SplitterWidth;
    
        //calculate the position of the points'
        if (control.Orientation == Orientation.Horizontal)
        {
            points[0] = new Point((w / 2), d + (sW / 2));
            points[1] = new Point(points[0].X - 10, points[0].Y);
            points[2] = new Point(points[0].X + 10, points[0].Y);
        }
        else
        {
            points[0] = new Point(d + (sW / 2), (h / 2));
            points[1] = new Point(points[0].X, points[0].Y - 10);
            points[2] = new Point(points[0].X, points[0].Y + 10);
        }
    
        foreach (Point p in points)
        {
            p.Offset(-2, -2);
            e.Graphics.FillEllipse(SystemBrushes.ControlDark,
                new Rectangle(p, new Size(3, 3)));
    
            p.Offset(1, 1);
            e.Graphics.FillEllipse(SystemBrushes.ControlLight,
                new Rectangle(p, new Size(3, 3)));
        }
    }
