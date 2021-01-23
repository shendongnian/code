    public class TypeValue
    {
        public Type Type { get; private set; }
        public object Value { get; set; }
        public T GetValueAs<T>()
        {
            if (Value == null)
                return default(T);
            return (T)Value;
        }
    }
    TypeValue a = new TypeValue();
    a.Value = 1;
    int b = a.GetValueAs<int>();
