    public sealed class Reference<T>
        where T: struct
    {
        public T Value;
        public Reference(T value)
        {
            Value = value;
        }
    }
