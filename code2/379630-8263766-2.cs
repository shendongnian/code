    class Pie
    {
        public Point Center { get; set; }
        public double Radius { get; set; }
        public Vector ZeroDegrees { get; set; }
        public bool ClockwisePositive { get; set; }
        public double GetAngle(Point p)
        {
            if (ClockwisePositive)
                return (Vector.AngleBetween(p - Center, ZeroDegrees) + 360) % 360;
            else
                return (Vector.AngleBetween(ZeroDegrees, p - Center) + 360) % 360;
        }
        public bool Contains(Point p)
        {
            return (p - Center).Length <= Radius;
        }
        public class Slice
        {
            public Pie Parent { get; set; }
            public double DirectionDegrees { get; set; }
            public double SizeDegrees { get; set; }
            public bool Contains(Point p)
            {
                if (!Parent.Contains(p))
                    return false;
                double angle = Parent.GetAngle(p);
                double minAngle = (DirectionDegrees - SizeDegrees / 2 + 360) % 360;
                double maxAngle = (DirectionDegrees + SizeDegrees / 2 + 360) % 360;
                if (minAngle < maxAngle)
                    return minAngle <= angle && angle <= maxAngle;
                else
                    return angle >= minAngle || angle <= maxAngle;
            }
        }
    }
