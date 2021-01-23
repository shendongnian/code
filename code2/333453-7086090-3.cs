    public struct FrameLimits
    {
        private int? yval;
        public int MaxY
        {
            get
            {
                return yval.HasValue ? yval.Value : 220;
            }
            set
            {
                yval = value;
            }
        }
    }
