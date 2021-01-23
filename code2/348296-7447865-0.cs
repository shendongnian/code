    class CharState
    {
        private static Random rnd = new Random();
        private object RandomLock = new object();
        public int x { get; private set; }
        public int y { get; private set; }
        public readonly char ch;
        public CharState(char c)
        {
           ch = c;
           SetRandomPos();
        }
        public void SetRandomPos()
        {
            lock (RandomLock)
            {
                // set x and y
            }
        }
    }
