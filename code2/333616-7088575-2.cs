    public abstract class ValuePair
    {
        public string Name { get; set;}
        public abstract object RawValue { get; }
    }
    public class ValuePair<T> : ValuePair
    {
        public T Value { get; set; }              
        public object RawValue { get { return Value; } }
    }
