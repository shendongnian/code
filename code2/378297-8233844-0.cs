      // ...
      StreamGeometry geom = new StreamGeometry();
      DrawLines(geom);
      Pen p = new Pen(Brushes.Black, 10);
      p.LineJoin = PenLineJoin.Round;
      p.EndLineCap = PenLineCap.Round;
      p.StartLineCap = PenLineCap.Round;
      PathGeometry pathGeomWide = geom.GetWidenedPathGeometry(p);
      PathGeometry pathGeom = pathGeomWide.GetOutlinedPathGeometry();
      Path myPath = new Path();
      myPath.Stroke = Brushes.Black;
      myPath.Data = pathGeom;
      myCanvas.Children.Add(myPath);
      // ...
    private static void DrawLines(StreamGeometry geom)
    {
      using (var context = geom.Open())
      {
        context.BeginFigure(new Point(20, 20), false, true);
        context.LineTo(new Point(100, 20), true, true);
        context.LineTo(new Point(100, 100), true, true);
        context.LineTo(new Point(200, 100), true, true);
      }
    }
