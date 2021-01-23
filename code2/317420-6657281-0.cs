    // this works
    BoolLikeC evil = 7;
    if (evil) Console.WriteLine("7 is so true");
    // and this works too
    if ((BoolLikeC)7) Console.WriteLine("7 is so true");
    // but this doesn't
    if (7) Console.WriteLine("7 is so true");
    // ...
    public struct BoolLikeC
    {
        private readonly int _value;
        public int Value { get { return _value; } }
        public BoolLikeC(int value)
        {
            _value = value;
        }
                
        public static implicit operator bool(BoolLikeC x)
        {
            return (x.Value != 0);
        }
        public static implicit operator BoolLikeC(int x)
        {
            return new BoolLikeC(x);
        }
    }
