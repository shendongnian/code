    public static class VectorExtentions
    {
        public static Point Rotate(this Point pt, double angle, Point center)
        {
            Vector v = new Vector(pt.X - center.X, pt.Y - center.Y).Rotate(angle);
            return new Point(v.X + center.X, v.Y + center.Y);
        }
        public static Vector Rotate(this Vector v, double degrees)
        {
            return v.RotateRadians(degrees * Math.PI / 180);
        }
        public static Vector RotateRadians(this Vector v, double radians)
        {
            double ca = Math.Cos(radians);
            double sa = Math.Sin(radians);
            return new Vector(ca * v.X - sa * v.Y, sa * v.X + ca * v.Y);
        }
    }
