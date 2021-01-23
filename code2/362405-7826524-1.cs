        class LineSegment
        {
            public double X1 { get; set; }
            public double X2 { get; set; }
            public double Y1 { get; set; }
            public double Y2 { get; set; }
        }
        private static bool SegmentsIntersect(LineSegment A, LineSegment B)
        {
            double x1 = A.X1, x2 = A.X2, x3 = B.X1, x4 = B.X2;
            double y1 = A.Y1, y2 = A.Y2, y3 = B.Y1, y4 = B.Y2;
            double denominator = (y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1);
            double ua = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3)) / denominator;
            double ub = ((x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3)) / denominator;
            if (denominator == 0)
                return false;
            return (ua > 0 && ua < 1 && ub > 0 && ub < 1);
        }
        private static bool RectIntersectsLine(Rect A, LineSegment B)
        {
            return (SegmentsIntersect(B, new LineSegment { X1 = A.X, Y1 = A.Y, X2 = A.X, Y2 = A.Y + A.Height }) ||
                SegmentsIntersect(B, new LineSegment { X1 = A.X, Y1 = A.Y + A.Height, X2 = A.X + A.Width, Y2 = A.Y + A.Height }) ||
                SegmentsIntersect(B, new LineSegment { X1 = A.X + A.Width, Y1 = A.Y + A.Height, X2 = A.X + A.Width, Y2 = A.Y }) ||
                SegmentsIntersect(B, new LineSegment { X1 = A.X + A.Width, Y1 = A.Y, X2 = A.X, Y2 = A.Y }));
        }
