    void DrawGraphics(Graphics g, Pen pen, Brush brush)
    {
        float xDiff=oppPt.X-keyPt.X;
        float yDiff=oppPt.Y-keyPt.Y;
        float xMid=(oppPt.X+keyPt.X)/2;
        float yMid=(oppPt.Y+keyPt.Y)/2;
        // Define path with the geometry information only
        var path = new GraphicsPath();
        path.AddLines(new PointF[] {
            keyPt,
            new PointF(xMid + yDiff/2, yMid-xDiff/2),
            oppPt,
        });
        path.CloseFigure();
        // Fill Triangle
        g.FillPath(brush, path);
        // Draw Triangle
        g.DrawPath(pen, path);
    }
