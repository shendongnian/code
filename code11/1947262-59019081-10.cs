    public readonly struct Logical : IEquatable<Logical>
    {
        public Logical(int value)
        {
            Value = value == 0 ? 0 : 1;
        }
        public Logical(bool cond)
        {
            Value = cond ? 1 : 0;
        }
        public int Value { get; }
        ... conversions and overrides
    }
