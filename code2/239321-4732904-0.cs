		private DrawingVisual CreateTriangle()
  		{
     		DrawingVisual triangle = new DrawingVisual();
     		using ( DrawingContext dc = triangle.RenderOpen() )
     		{
				Point start = new Point(0, 50);
				LineSegment[] segments = new LineSegment[]{ new LineSegment(new Point(50,0), true), new LineSegment(new Point(50, 100), true) };
				PathFigure figure = new PathFigure(start, segments, true);
				PathGeometry geo = new PathGeometry(new PathFigure[]{figure});
				dc.DrawGeometry(Brushes.Red, null, geo);
				
        		Pen drawingPen = new Pen(Brushes.Black,3);
         		dc.DrawLine(drawingPen, new Point(0, 50), new Point(50, 0));
         		dc.DrawLine(drawingPen, new Point(50, 0), new Point(50, 100));
         		dc.DrawLine(drawingPen, new Point(50, 100), new Point(0, 50));	
    		}
     		return triangle;
  		}
