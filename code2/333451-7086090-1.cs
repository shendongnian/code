    public struct frameLimits
    {
        public struct Max
        {
            private int yval;
            public int Y
            {
                get
                {
                    return yval;
                }
                set
                {
                    yval = value;
                }
            }
        }
        public Max MaxValue;
    }
