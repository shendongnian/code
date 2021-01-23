    public class ClippedBorder : Border
    {
        protected override Geometry GetLayoutClip(Size layoutSlotSize)
        {
            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = new PathFigureCollection();
            //Point1:  0, 2
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(0, 2);
            //Point2: 12, 2
            LineSegment lineSegment1 = new LineSegment();
            lineSegment1.Point = new Point(12, 2);
            //Point3: 12, 0
            LineSegment lineSegment2 = new LineSegment();
            lineSegment2.Point = new Point(12, 0);
            //Point4: Width of Border - 12, 0
            LineSegment lineSegment3 = new LineSegment();
            lineSegment3.Point = new Point(this.ActualWidth-12, 0);
            //Point5: Width of Border - 12, 2
            LineSegment lineSegment4 = new LineSegment();
            lineSegment4.Point = new Point(this.ActualWidth-12, 2);
            //Point5: Width of Border, 2
            LineSegment lineSegment5 = new LineSegment();
            lineSegment5.Point = new Point(this.ActualWidth, 2);
            //Point6: Width of Border, Height of Border
            LineSegment lineSegment6 = new LineSegment();
            lineSegment6.Point = new Point(this.ActualWidth, this.ActualHeight);
            //Point7: 0, Height of Border 
            LineSegment lineSegment7 = new LineSegment();
            lineSegment7.Point = new Point(0, this.ActualHeight);
            pathFigure.Segments.Add(lineSegment1);
            pathFigure.Segments.Add(lineSegment2);
            pathFigure.Segments.Add(lineSegment3);
            pathFigure.Segments.Add(lineSegment4);
            pathFigure.Segments.Add(lineSegment5);
            pathFigure.Segments.Add(lineSegment6);
            pathFigure.Segments.Add(lineSegment7);
            pathGeometry.Figures.Add(pathFigure);
            return pathGeometry;
        }
    }
