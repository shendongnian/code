    public struct Coordinate
    {
        public int X
        {
            get { return _x; }
        }
        private int _x;
        public int Y
        {
            get { return _y; }
        }
        private int _y;
        public Coordinate(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
