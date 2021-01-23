    public abstract class ValuePair
    {
        public string Name { get; set; }
        public object Value
        {
            get { return GetValue(); }
            set { SetValue(value); }
        }
        protected abstract object GetValue();
        protected abstract void SetValue(object value);
    }
    public class ValuePair<T> : ValuePair
    {
        protected override object GetValue() { return Value; }
        protected override void SetValue(object value) { Value = (T)value; }
        public new T Value { get; set; }
    }
