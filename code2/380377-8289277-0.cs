    struct NonNullInteger
    {
        private readonly int _valueMinusOne;
    
        public int Value
        {
            get { return _valueMinusOne + 1; }
        }
    
        public NonNullInteger(int value)
        {
            if (value == 0)
            {
                throw new ArgumentOutOfRangeException("value");
            }
    
            _valueMinusOne = value - 1;
        }
    }
