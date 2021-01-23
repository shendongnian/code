        /// <summary>
        /// Creates a rectangle based on two points.
        /// </summary>
        /// <param name="p1">Point 1</param>
        /// <param name="p2">Point 2</param>
        /// <returns>Rectangle</returns>
        public static RectangleF GetRectangle(PointF p1, PointF p2)
        {
            float top = Math.Min(p1.Y, p2.Y);
            float bottom = Math.Max(p1.Y, p2.Y);
            float left = Math.Min(p1.X, p2.X);
            float right = Math.Max(p1.X, p2.X);
            RectangleF rect = RectangleF.FromLTRB(left, top, right, bottom);
            return rect;
        }
