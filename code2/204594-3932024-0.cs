    class Thing
    {
        public bool IsReadOnly {get; set;}
        private int _X;
        public int X
        {
            get
            {
                return _X;
            }
            set
            {
                if(IsReadOnly)
                {
                    throw new ArgumentException("X");
                }
                _X = value;
            }
        }
    }
