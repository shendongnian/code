    public class TypeValue<T>
    {
        public Type Type { get { return typeof(T); } }
        public T Value { get; set; }
    }
    TypeValue<int> a = new TypeValue<int>();
    a.Value = 1;
    int b = a.Value;
    Type c = a.Type;
