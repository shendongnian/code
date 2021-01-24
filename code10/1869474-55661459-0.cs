    class Point
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public Point(int x2, int y2)
        {
            x = x2;
            y = y2;
        }
        public override string ToString()
        {
            return $"x:{x,-3} y:{y,-3}";
        }
    }
