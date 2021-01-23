    public struct ImmutableValueType
    {
        private readonly int myInt;
        public ImmutableValueType(int i) { this.myInt = i; }
   
        public int MyInt { get { return this.myInt; } }
    }
