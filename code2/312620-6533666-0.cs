    class Point
    {
        protected int x,y;
        public Point(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
        public readonly int X { get x; }
        public readonly int Y { get y; }
    }
