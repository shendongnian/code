    public struct Pair
    {
        public readonly int x;
        public readonly int y;
        public Pair(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void M(ref Pair p)
        {
            int oldX = x;
            int oldY = y;
            // Something happens here
            Debug.Assert(x == oldX);
            Debug.Assert(y == oldY);
        }
    }
