    public static GraphicsPath Offset(GraphicsPath path, float offset)
    {
        if (path == null)
            throw new ArgumentNullException("path");
        // death from natural causes
        if (path.PointCount < 2)
            throw new ArgumentException(null, "path");
        PointF[] points = new PointF[path.PointCount];
        for (int i = 0; i < path.PointCount; i++)
        {
            PointF current = path.PathPoints[i];
            PointF prev = GetPreviousPoint(path, i);
            PointF next = GetNextPoint(path, i);
            
            PointF offsetPoint = Offset(prev, current, next, offset);
            points[i] = offsetPoint;
        }
        GraphicsPath newPath = new GraphicsPath(points, path.PathTypes);
        return newPath;
    }
    // get the closing point for a figure or null if none was found
    private static PointF? GetClosingPoint(GraphicsPath path, int index)
    {
        for (int i = index + 1; i < path.PointCount; i++)
        {
            if (IsClosingPoint(path, i))
                return path.PathPoints[i];
        }
        return null;
    }
    // get the starting point for a figure or null if none was found
    private static PointF? GetStartingPoint(GraphicsPath path, ref int index)
    {
        for (int i = index - 1; i >= 0; i--)
        {
            if (IsStartingPoint(path, i))
            {
                index = i;
                return path.PathPoints[i];
            }
        }
        return null;
    }
    // get a previous point to compute normal vector at specified index
    private static PointF GetPreviousPoint(GraphicsPath path, int index)
    {
        if (IsStartingPoint(path, index))
        {
            PointF? closing = GetClosingPoint(path, index);
            if (closing.HasValue)
                return closing.Value;
        }
        else
        {
            return path.PathPoints[index - 1];
        }
        // we are on an unclosed end point, emulate a prev point on the same line using next point
        PointF point = path.PathPoints[index];
        PointF next = path.PathPoints[index + 1];
        return VectorF.Add(point, VectorF.Substract(point, next));
    }
    // get a next point to compute normal vector at specified index
    private static PointF GetNextPoint(GraphicsPath path, int index)
    {
        if (IsClosingPoint(path, index))
        {
            int startingIndex = index;
            PointF? starting = GetStartingPoint(path, ref startingIndex);
            if (starting.HasValue)
            {
                // some figures (Ellipse) are closed with the same point as the starting point
                // in this case, we need the starting point's next point
                if (starting.Value != path.PathPoints[index])
                    return starting.Value;
                return GetNextPoint(path, startingIndex);
            }
        }
        else if ((index != (path.PointCount - 1)) && (!IsStartingPoint(path, index + 1)))
        {
            return path.PathPoints[index + 1];
        }
        // we are on an unclosed end point, emulate a next point on the same line using previous point
        PointF point = path.PathPoints[index];
        PointF prev = path.PathPoints[index - 1];
        return VectorF.Add(point, VectorF.Substract(point, prev));
    }
    // determine if a point is a closing point
    private static bool IsClosingPoint(GraphicsPath path, int index)
    {
        return (path.PathTypes[index] & (byte)PathPointType.CloseSubpath) == (byte)PathPointType.CloseSubpath;
    }
    // determine if a point is a starting point
    private static bool IsStartingPoint(GraphicsPath path, int index)
    {
        return (path.PathTypes[index] == (byte)PathPointType.Start);
    }
    // offsets a Point using the normal vector (actually computed using intersection or 90° rotated vectors)
    private static PointF Offset(PointF prev, PointF current, PointF next, float offset)
    {
        VectorF vnext = VectorF.Substract(next, current);
        vnext = vnext.DegreeRotate(Math.Sign(offset) * 90);
        vnext = vnext.Normalize() * Math.Abs(offset);
        PointF pnext1 = current + vnext;
        PointF pnext2 = next + vnext;
        VectorF vprev = VectorF.Substract(prev, current);
        vprev = vprev.DegreeRotate(-Math.Sign(offset) * 90);
        vprev = vprev.Normalize() * Math.Abs(offset);
        PointF pprev1 = current + vprev;
        PointF pprev2 = prev + vprev;
        PointF ix = VectorF.GetIntersection(pnext1, pnext2, pprev1, pprev2);
        if (ix.IsEmpty)
        {
            // 3 points on the same line, just translate (both vectors are identical)
            ix = current + vnext;
        }
        return ix;
    }
    // a useful Vector class (does not exists in GDI+, why?)
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct VectorF : IFormattable, IEquatable<VectorF>
    {
        private float _x;
        private float _y;
        public VectorF(float x, float y)
        {
            _x = x;
            _y = y;
        }
        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
        public double Length
        {
            get
            {
                return Math.Sqrt(_x * _x + _y * _y);
            }
        }
        public VectorF Rotate(double angle)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);
            return new VectorF(_x * cos - _y * sin, _x * sin + _y * cos);
        }
        public VectorF DegreeRotate(double angle)
        {
            return Rotate(DegreeToGradiant(angle));
        }
        public static PointF GetIntersection(PointF start1, PointF end1, PointF start2, PointF end2)
        {
            float denominator = ((end1.X - start1.X) * (end2.Y - start2.Y)) - ((end1.Y - start1.Y) * (end2.X - start2.X));
            if (denominator == 0) // parallel
                return PointF.Empty;
            float numerator = ((start1.Y - start2.Y) * (end2.X - start2.X)) - ((start1.X - start2.X) * (end2.Y - start2.Y));
            float r = numerator / denominator;
            PointF result = new PointF();
            result.X = start1.X + (r * (end1.X - start1.X));
            result.Y = start1.Y + (r * (end1.Y - start1.Y));
            return result;
        }
        public static PointF Add(PointF point, VectorF vector)
        {
            return new PointF(point.X + vector._x, point.Y + vector._y);
        }
        public static VectorF Add(VectorF vector1, VectorF vector2)
        {
            return new VectorF(vector1._x + vector2._x, vector1._y + vector2._y);
        }
        public static VectorF Divide(VectorF vector, float scalar)
        {
            return vector * (1.0f / scalar);
        }
        public static VectorF Multiply(float scalar, VectorF vector)
        {
            return new VectorF(vector._x * scalar, vector._y * scalar);
        }
        public static VectorF Multiply(VectorF vector, float scalar)
        {
            return Multiply(scalar, vector);
        }
        public static VectorF operator *(float scalar, VectorF vector)
        {
            return Multiply(scalar, vector);
        }
        public static VectorF operator *(VectorF vector, float scalar)
        {
            return Multiply(scalar, vector);
        }
        public static PointF operator -(PointF point, VectorF vector)
        {
            return Substract(point, vector);
        }
        public static PointF operator +(VectorF vector, PointF point)
        {
            return Add(point, vector);
        }
        public static PointF operator +(PointF point, VectorF vector)
        {
            return Add(point, vector);
        }
        public static VectorF operator +(VectorF vector1, VectorF vector2)
        {
            return Add(vector1, vector2);
        }
        public static VectorF operator /(VectorF vector, float scalar)
        {
            return Divide(vector, scalar);
        }
        public static VectorF Substract(PointF point1, PointF point2)
        {
            return new VectorF(point1.X - point2.X, point1.Y - point2.Y);
        }
        public static PointF Substract(PointF point, VectorF vector)
        {
            return new PointF(point.X - vector._x, point.Y - vector._y);
        }
        public static double AngleBetween(VectorF vector1, VectorF vector2)
        {
            double y = (vector1._x * vector2._y) - (vector2._x * vector1._y);
            double x = (vector1._x * vector2._x) + (vector1._y * vector2._y);
            return Math.Atan2(y, x);
        }
        private static double GradiantToDegree(double angle)
        {
            return (angle * 180) / Math.PI;
        }
        private static double DegreeToGradiant(double angle)
        {
            return (angle * Math.PI) / 180;
        }
        public static double DegreeAngleBetween(VectorF vector1, VectorF vector2)
        {
            return GradiantToDegree(AngleBetween(vector1, vector2));
        }
        public VectorF Normalize()
        {
            if (Length == 0)
                return this;
            VectorF vector = this / (float)Length;
            return vector;
        }
        public override string ToString()
        {
            return ToString(null, null);
        }
        public string ToString(string format, IFormatProvider provider)
        {
            return string.Format(provider, "{0:" + format + "};{1:" + format + "}", _x, _y);
        }
        public override int GetHashCode()
        {
            return _x.GetHashCode() ^ _y.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !(obj is VectorF))
                return false;
            return Equals(this, (VectorF)obj);
        }
        public bool Equals(VectorF value)
        {
            return Equals(this, value);
        }
        public static bool Equals(VectorF vector1, VectorF vector2)
        {
            return (vector1._x.Equals(vector2._x) && vector1._y.Equals(vector2._y));
        }
    }
