    // This type works pretty much the same way an enum works;
    // each specific value can be cast to/from an int, and each has
    // a specific name that is returned on calling ToString().
    public sealed class MyEnum
    {
        private readonly int _value;
        private readonly string _name;
    
        // private constructor -- ensure that the static members you define below
        // are the only MyEnum instances accessible from any outside code
        private MyEnum(int value, string name)
        {
            _value = value;
            _name = name;
        }
        // no need to override Equals or GetHashCode, believe it or not --
        // one instance per value means we can use reference equality and
        // that should be just fine
        public override string ToString()
        {
            return _name;
        }
        // provide direct access only to these members
        public static readonly MyEnum ValueA = new MyEnum(0, "ValueA");
        public static readonly MyEnum ValueB = new MyEnum(1, "ValueB");
    
        // this member is only available to you within the current assembly
        internal static readonly MyEnum Reserved = new MyEnum(-1, "Reserved");
    }
