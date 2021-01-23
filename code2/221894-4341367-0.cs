    base.OnPaint(e);
    var g = e.Graphics;
    var width = g.VisibleClipBounds.Width;
    var height = g.VisibleClipBounds.Height;
    var rotationPoint = new PointF(width / 2, height / 2); ;
    // draw center point
    g.FillRectangle(Brushes.Red, new RectangleF(rotationPoint.X - 5, rotationPoint.Y - 5, 10, 10));
    using (var path = new GraphicsPath())
    {
        var rectangle = new RectangleF((width - 10) / 2, 0, 10, 10);
        var m = new Matrix();
        m.RotateAt(90, rotationPoint);
        path.AddRectangle(rectangle);
        path.Transform(m);
        // draw rotated point
        g.FillPath(Brushes.Black, path);
    }
