    private DrawingVisual CreateTriangle()
    {
        DrawingVisual triangle = new DrawingVisual();
        using ( DrawingContext dc = triangle.RenderOpen() )
     	{
           var start = new Point(0, 50);
           var segments = new LineSegment[]{ 
                                      new LineSegment(new Point(50,0), true), 
                                      new LineSegment(new Point(50, 100), true) };
           var figure = new PathFigure(start, segments, true);
           var geo = new PathGeometry(new PathFigure[]{figure});
           dc.DrawGeometry(Brushes.Red, null, geo);
				
           var drawingPen = new Pen(Brushes.Black,3);
           dc.DrawLine(drawingPen, new Point(0, 50), new Point(50, 0));
           dc.DrawLine(drawingPen, new Point(50, 0), new Point(50, 100));
           dc.DrawLine(drawingPen, new Point(50, 100), new Point(0, 50));	
        }
            
        return triangle;
    }
