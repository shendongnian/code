        public void M(ref Pair p)
        {
            int oldX = this.x;
            int oldY = this.y;
            p = new Pair(0, 0);
            Debug.Assert(this.x == oldX);
            Debug.Assert(this.y == oldY);
        }
    ...
        Pair myPair = new Pair(10, 20);
        myPair.M(ref myPair);
