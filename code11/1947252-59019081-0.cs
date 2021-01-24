    public readonly struct Logical
    {
        public Logical(int value)
        {
            Value = value;
        }
        public Logical(bool cond)
        {
            Value = cond ? 1 : 0;
        }
        public int Value { get; }
        ...
    }
