    public struct Point
    {
        private readonly int x;
        public int X { get { return x; } }
        private readonly int y;
        public int Y { get { return y; } }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    ...
    Point p1 = new Point(1, 2);
