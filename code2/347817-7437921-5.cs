    public class Rectangle
    {
        Point CornerA = new Point();
        Point CornerB = new Point();
        Point CornerC = new Point();
        Point CornerD = new Point();
        Dictionary<int, Point> points = new Dictionary<int, Point>();
        public Rectangle()
        {
            points.Add(0, CornerA);
            points.Add(1, CornerB);
            points.Add(2, CornerC);
            points.Add(3, CornerD);
        }
        public void MoveAPoint(int id, Point newPoint)
        {
            // Get the old point
            Point oldPoint = points[id];
            // Get the previous point
            Point pointPrevious = points[(id + 3) % 4];
            // Get the next point
            Point pointNext = points[(id + 1) % 4];
            // Get the opposite point
            Point pointOpposite = points[(id + 2) % 4];
            // I call sides points, but they are actually vectors.
            // Get side from 'oldPoint' to 'pointPrevious'.
            Point sidePrevious = pointPrevious.Substract(oldPoint);
            // Get side from 'oldPoint' to 'pointNext'.
            Point sideNext = pointNext.Substract(oldPoint);
            // Get side from 'pointOpposite' to 'newPoint'.
            Point sideTransversal = newPoint.Substract(pointOpposite);
            PointF previousProjection;
            PointF nextProjection;
            // ---------- Last edit starts here. ----------
            if (sideNext.X == 0 && sideNext.Y == 0)
            {
                if (sidePrevious.X == 0 && sidePrevious.Y == 0)
                {
                    return;
                }
                sideNext = new PointF(-sidePrevious.Y, sidePrevious.X);
            }
            else
            {
                sidePrevious = new PointF(-sideNext.Y, sideNext.X);
            }
            // ---------- Last edit ends here. ----------
            Point previousProjection = Projection(delta, sidePrevious);
            Point nextProjection = Projection(delta, sideNext);
            pointNext = pointOpposite.AddPoints(previousProjection);
            pointPrevious = pointOpposite.AddPoints(nextProjection);
            pointNext.SetToPoint(pointNext.AddPoints(previousProjection));
            pointPrevious.SetToPoint(pointPrevious.AddPoints(nextProjection));
            oldPoint.SetToPoint(newPoint);
        }
        private static Point Projection(Point vectorA, Point vectorB)
        {
            Point vectorBUnit = new Point(vectorB.X, vectorB.Y);
            vectorBUnit = vectorBUnit.Normalize();
            decimal dotProduct = vectorA.X * vectorBUnit.X + vectorA.Y * vectorBUnit.Y;
            return vectorBUnit.MultiplyByDecimal(dotProduct);
        }
    }
    public static class ExtendPoint
    {
        public static Point Normalize(this Point pointA)
        {
            double length = Math.Sqrt(pointA.X * pointA.X + pointA.Y * pointA.Y);
            return new Point(pointA.X / length, pointA.Y / length);
        }
        public static Point MultiplyByDecimal (this Point point, decimal length)
        {
            return new Point((int)(point.X * length), (int)(point.Y * length));
        }
        public static Point AddPoints(this Point firstPoint, Point secondPoint)
        {
            return new Point(firstPoint.X + secondPoint.X, firstPoint.Y + secondPoint.Y);
        }
        public static Point Substract(this Point firstPoint, Point secondPoint)
        {
            return new Point(firstPoint.X - secondPoint.X, firstPoint.Y - secondPoint.Y);
        }
        public static void SetToPoint(this Point oldPoint, Point newPoint)
        {
            oldPoint.X = newPoint.X;
            oldPoint.Y = newPoint.Y;
        }
    }
