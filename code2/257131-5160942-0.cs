    abstract class Container
    {
        public abstract object RawValue { get; }
    }
    class Container<T> : Container
    {
        public override object RawValue
        {
            get { return this.Value; }
        }
        T Value
        {
            get;
            private set;
        }
        public Container(T value)
        {
            Value = value;
        }
    }
