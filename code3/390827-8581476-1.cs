    public struct Nullable<T> 
    {
        public bool HasValue { get { return Value != null; } }
        public T Value { get; set; }
    }
