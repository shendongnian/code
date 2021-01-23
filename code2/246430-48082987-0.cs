    class ReferenceType<T> where T : struct
    {
        public T Value { get; set; }
        public ReferenceType(T value) { this.Value = value; }
        public static implicit operator ReferenceType<T>(T b)
        {
            ReferenceType<T> r = new ReferenceType<T>(b);
            return r;
        }
        public static implicit operator T(ReferenceType<T> b)
        {
            return b.Value;
        }
    }
    ReferenceType<float> f1 = new ReferenceType(100f);
    f1 = 200f;
    float f2 = f1;
