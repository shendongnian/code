    public sealed class MyType
    {
        public int Value{get {return _value;}}
        private readonly int _value;
        public MyType(int value)
        {
            _value = value;
        }
    }
