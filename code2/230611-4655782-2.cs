    public class LineSegment
    {
        private readonly LineEquation line;
        private RectangleF bindingRectangle;
        public PointF A { get; private set; }
        public PointF B { get; private set; }
        public LineSegment(PointF a, PointF b)
        {
            A = a;
            B = b;
            line = new LineEquation(a, b);
            bindingRectangle = new RectangleF(
                Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), 
                Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y));
        }
        public PointF? Intersect(LineSegment other)
        {
            var p = line.Intersect(other.line);
            if (p == null) return null;
            if (bindingRectangle.Contains(p.Value) &&
                other.bindingRectangle.Contains(p.Value))
            {
                return p;
            }
            return null;
        }
        public float Distance(PointF p)
        {
            if (LineEquation.IsBetween(line.GetNormalAt(A), p, line.GetNormalAt(B)))
            {
                return line.Distance(p);
            }
            return Math.Min(Distance(A, p), Distance(B, p));
            
        }
        static float Distance(PointF p1, PointF p2)
        {
            var x = p1.X - p2.X;
            var y = p1.Y - p2.Y;
            return (float) Math.Sqrt(x*x + y*y);
        }
        public PointF? IntersectAtDistance(LineSegment segmentToCut, float width)
        {
            // always assuming other.A is the farthest end
            var distance = width* (line.IsAboveOrRightOf(segmentToCut.A) ? 1 : -1);
            var parallelLine = line.GetParallelLine(distance);
            var p = parallelLine.Intersect(segmentToCut.line);
            if (p.HasValue)
            {
                if (LineEquation.IsBetween(line.GetNormalAt(A), p.Value, line.GetNormalAt(B)) &&
                    segmentToCut.bindingRectangle.Contains(p.Value))
                {
                    return p;
                }
            }
            List<PointF> points = new List<PointF>();
            points.AddRange(segmentToCut.line.Intersect(new CircleEquation(width, A)));
            points.AddRange(segmentToCut.line.Intersect(new CircleEquation(width, B)));
            return GetNearestPoint(segmentToCut.A, points);
        }
        public static PointF GetNearestPoint(PointF p, IEnumerable<PointF> points)
        {
            float minDistance = float.MaxValue;
            PointF nearestPoint = p;
            foreach (var point in points)
            {
                var d = Distance(p, point);
                if (d < minDistance)
                {
                    minDistance = d;
                    nearestPoint = point;
                }
            }
            return nearestPoint;
        }
    }
    public class LineEquation
    {
        private readonly float a;
        private readonly float b;
        
        private readonly bool isVertical;
        private readonly float xConstForVertical;
        public LineEquation(float a, float b)
        {
            this.a = a;
            this.b = b;
            isVertical = false;
        }
        public LineEquation(float xConstant)
        {
            isVertical = true;
            xConstForVertical = xConstant;
        }
        public LineEquation(float a, PointF p)
        {
            this.a = a;
            b = p.Y - a*p.X;
            isVertical = false;
        }
        public LineEquation(PointF p1, PointF p2)
        {
            if (p1.X == p2.X)
            {
                isVertical = true;
                xConstForVertical = p1.X;
                return;
            }
            a = (p1.Y - p2.Y)/(p1.X - p2.X);
            b = p1.Y - a * p1.X;
            isVertical = false;
        }
        public PointF? Intersect(float x)
        {
            if (isVertical)
            {
                return null;
            }
            return new PointF(x, a*x + b);
        }
        public PointF? Intersect(LineEquation other)
        {
            if (isVertical && other.isVertical) return null;
            if (a == other.a) return null;
            if (isVertical) return other.Intersect(xConstForVertical);
            if (other.isVertical) return Intersect(other.xConstForVertical);
            // both have slopes and are not parallel
            var x = (b - other.b) / (other.a - a);
            return Intersect(x);
        }
        public float Distance(PointF p)
        {
            if (isVertical)
            {
                return Math.Abs(p.X - xConstForVertical);
            }
            var p1 = Intersect(0).Value;
            var p2 = Intersect(100).Value;
            
            var x1 = p.X - p1.X;
            var y1 = p.Y - p1.Y;
            var x2 = p2.X - p1.X;
            var y2 = p2.Y - p1.Y;
            return (float) (Math.Abs(x1*y2 - x2*y1) / Math.Sqrt(x2*x2 + y2*y2));
        }
        public bool IsAboveOrRightOf(PointF p)
        {
            return isVertical ? 
                xConstForVertical > p.X : 
                a*p.X + b > p.Y;
        }
        public static bool IsBetween(LineEquation l1, PointF p, LineEquation l2)
        {
            return l1.IsAboveOrRightOf(p) ^ l2.IsAboveOrRightOf(p);
        }
        public LineEquation GetParallelLine(float distance)
        {
            if (isVertical) return new LineEquation(xConstForVertical + distance);
            var angle = Math.Atan(a);
            float dy = (float) (distance/Math.Sin(angle));
            return new LineEquation(a, b - dy);
        }
        public LineEquation GetNormalAt(PointF p)
        {
            if (isVertical) return new LineEquation(p.X);
            var newA = -1/a;
            var newB = (a + 1/a)*p.X + b;
            return new LineEquation(newA, newB);
        }
        public PointF[] Intersect(CircleEquation circle)
        {
            var cx = circle.Center.X;
            var cy = circle.Center.Y;
            var r = circle.Radius;
            
            if (isVertical)
            {
                var distance = Math.Abs(cx - xConstForVertical);
                if (distance > r) return new PointF[0];
                if (distance == r) return new[] {new PointF(xConstForVertical, cy) };
                // two intersections
                var dx = cx - xConstForVertical;
                
                var qe = new QuadraticEquation(
                    1,
                    -2 * cy,
                    r * r - dx * dx);
                return qe.Solve();
            }
            var t = b - cy;
            var q = new QuadraticEquation(
                1 + a*a,
                2*a*t - 2*cx,
                cx*cx + t*t - r*r);
            var solutions = q.Solve();
            for (var i = 0; i < solutions.Length; i++) 
               solutions[i] = Intersect(solutions[i].X).Value;
            return solutions;
        }
    }
    public class CircleEquation
    {
        public float Radius { get; private set; }
        public PointF Center { get; private set; }
        public CircleEquation(float radius, PointF center)
        {
            Radius = radius;
            Center = center;
        }
    }
    public class QuadraticEquation
    {
        public float A { get; private set; }
        public float B { get; private set; }
        public float C { get; private set; }
        public QuadraticEquation(float a, float b, float c)
        {
            A = a;
            B = b;
            C = c;
        }
        public PointF Intersect(float x)
        {
            return new PointF(x, A*x*x + B*x + C);
        }
        public PointF[] Solve()
        {
            var d = B*B - 4*A*C;
            if (d < 0) return new PointF[0];
            if (d == 0)
            {
                var x = -B / (2*A);
                return new[] { Intersect(x) };
            }
            var sd = Math.Sqrt(d);
            var x1 = (float) ((-B - sd) / (2f*A));
            var x2 = (float) ((-B + sd) / (2*A));
            return new[] { Intersect(x1), Intersect(x2) };
        }
    }
    public static class GraphicsPathExtension
    {
        public static GraphicsPath Shrink(this GraphicsPath originalPath, float width)
        {
            originalPath.CloseAllFigures();
            originalPath.Flatten();
            var parts = originalPath.SplitFigures();
            var shrunkPaths = new List<GraphicsPath>();
            foreach (var part in parts)
            {
                using (var widePath = new GraphicsPath(part.PathPoints, part.PathTypes))
                {
                    // widen the figure
                    widePath.Widen(new Pen(Color.Black, width * 2));
                    // pick the inner edge
                    var innerEdge = widePath.SplitFigures()[1];
                    var fixedPath = CleanPath(innerEdge, part, width);
                    if (fixedPath.PointCount > 0)
                        shrunkPaths.Add(fixedPath);
                }
            }
            // build the result
            originalPath.Reset();
            foreach (var p in shrunkPaths)
            {
                originalPath.AddPath(p, false);
            }
            return originalPath;
        }
        public static IList<GraphicsPath> SplitFigures(this GraphicsPath path)
        {
            var paths = new List<GraphicsPath>();
            var position = 0;
            while (position < path.PointCount)
            {
                var figureCount = CountNextFigure(path.PathData, position);
                var points = new PointF[figureCount];
                var types = new byte[figureCount];
                Array.Copy(path.PathPoints, position, points, 0, figureCount);
                Array.Copy(path.PathTypes, position, types, 0, figureCount);
                position += figureCount;
                paths.Add(new GraphicsPath(points, types));
            }
            return paths;
        }
        static int CountNextFigure(PathData data, int position)
        {
            var count = 0;
            for (var i = position; i < data.Types.Length; i++)
            {
                count++;
                if (0 != (data.Types[i] & (int)PathPointType.CloseSubpath))
                {
                    return count;
                }
            }
            return count;
        }
        static GraphicsPath CleanPath(GraphicsPath innerPath, GraphicsPath originalPath, float width)
        {
            var points = new List<PointF>();
            Region originalRegion = new Region(originalPath);
            // find first valid point
            int firstValidPoint = 0;
            IEnumerable<LineSegment> segs;
            
            while (IsPointTooClose(
                       innerPath.PathPoints[firstValidPoint], 
                       originalPath, originalRegion, width, out segs))
            {
                firstValidPoint++;
                if (firstValidPoint == innerPath.PointCount) return new GraphicsPath();
            }
            var prevP = innerPath.PathPoints[firstValidPoint];
            points.Add(prevP);
            for (int i = 1; i < innerPath.PointCount; i++)
            {
                var p = innerPath.PathPoints[(firstValidPoint + i) % innerPath.PointCount];
                if (!IsPointTooClose(p, originalPath, originalRegion, width, out segs))
                {
                    prevP = p;
                    points.Add(p);
                    continue;
                }
                var invalidSegment = new LineSegment(prevP, p);
                
                // found invalid point (too close or external to original figure)
                IEnumerable<PointF> cutPoints = 
                    segs.Select(seg => seg.IntersectAtDistance(invalidSegment, width).Value);
                var cutPoint = LineSegment.GetNearestPoint(prevP, cutPoints);
                // now add the cutPoint instead of 'p'.
                points.Add(cutPoint);
                prevP = cutPoint;
            }
            var types = new List<byte>();
            for (int i = 0; i < points.Count - 1; i++)
            {
                types.Add(1);
            }
            types.Add(129);
            return points.Count == 0 ?
                new GraphicsPath() :
                new GraphicsPath(points.ToArray(), types.ToArray());
        }
        static bool IsPointTooClose(
            PointF p, GraphicsPath path, Region region, 
            float distance, out IEnumerable<LineSegment> breakingSegments)
        {
            if (!region.IsVisible(p))
            {
                breakingSegments = new LineSegment[0];
                return true;
            }
            var segs = new List<LineSegment>();
            foreach (var seg in GetSegments(path))
            {
                if (seg.Distance(p) < distance)
                {
                    segs.Add(seg);
                }
            }
            breakingSegments = segs;
            return segs.Count > 0;
        }
        static public IEnumerable<LineSegment> GetSegments(GraphicsPath path)
        {
            for (var i = 0; i < path.PointCount; i++)
            {
                yield return 
                    new LineSegment(path.PathPoints[i], path.PathPoints[(i + 1) % path.PointCount]);
            }
        }
    }
