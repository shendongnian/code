    public struct Region
    {
        public Point Corner1 { get; }
        public Point Corner2 { get; }
        public Rectangle Rectangle { get; }
        public Region(Point corner1, Point corner2)
        {
            Corner1 = corner1;
            Corner2 = corner2;
            var leftMost = Math.Min(Corner1.X, Corner2.X);
            var topMost = Math.Min(Corner1.Y, Corner2.Y);
            var width = Math.Abs(Corner1.X - Corner2.X);
            var height = Math.Abs(Corner1.Y - Corner2.Y);
            Rectangle = new Rectangle(leftMost, topMost, width, height);
        }
        public static bool AnyOverlap(List<Region> regions)
        {
            if (regions == null || regions.Count == 1) return false;
            for (int i = 0; i < regions.Count - 1; i++)
            {
                for (int j = i + 1; j < regions.Count; j++)
                {
                    if (regions[i].Overlaps(regions[j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool Contains(Point p)
        {
            return p.X >= Rectangle.Left && p.X <= Rectangle.Right &&
                   p.Y >= Rectangle.Top && p.Y <= Rectangle.Bottom;
        }
        public bool Overlaps(Region other)
        {
            return Rectangle.Left < other.Rectangle.Right &&
                   Rectangle.Right > other.Rectangle.Left &&
                   Rectangle.Top > other.Rectangle.Bottom &&
                   Rectangle.Bottom < other.Rectangle.Top;
        }
        public override bool Equals(object obj)
        {
            return obj is Region && Equals(this, obj as Region?);
        }
        public override int GetHashCode()
        {
            return Rectangle.GetHashCode();
        }
    }
