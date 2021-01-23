    Point p1 = new Point(0, 50);
    Point p2 = new Point(50, 0);
    Point p3 = new Point(50, 100);
    StreamGeometry streamGeometry = new StreamGeometry();
    using (StreamGeometryContext geometryContext = streamGeometry.Open())   
    {
        geometryContext.BeginFigure(p1, true, true);
        PointCollection points = new PointCollection{ p2, p3 };
        geometryContext.PolyLineTo(points, true, true);
    }
    streamGeometry.Freeze();
    context.DrawGeometry(Brushes.Red, new Pen(Brushes.Black,3), streamGeometry);
