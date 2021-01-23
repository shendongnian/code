    public class Int32Holder
    {
        public int Value { get; set; }
    }
    class Foo
    {
        private readonly Int32Holder valueHolder;
        public int Value
        {
            get { return valueHolder.Value; }
            set { valueHolder.Value = value; }
        }
        public Foo(Int32Holder valueHolder)
        {
            this.valueHolder = valueHolder;
        }
    }
