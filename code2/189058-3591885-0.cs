    public sealed class MyEnum
    {
        public int Value { get; private set; }
    
        // private constructor
        private MyEnum(int value)
        {
            Value = value;
        }
        // provide direct access only to these members
        public static readonly MyEnum ValueA = new MyEnum(0);
        public static readonly MyEnum ValueB = new MyEnum(1);
    
        // this member is only available to you within the current assembly
        internal static readonly MyEnum Reserved = new MyEnum(-1);
    }
