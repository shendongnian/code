    public abstract class Field
    {
        protected Field() { }
        public abstract BoxedValue { get; set; }
        public abstract Type ValueType { get; }
    }
    public class Field<T> : Field
    {
        private T value; 
        public Field(T value) { this.value = value; }
        public T Value
        {
            get { return this.value; }
            set { this.value = value;; }
        }
        public override object BoxedValue
        {
            get { return this.value; }
            set { this.value = (T)value; }
        }
        public override Type ValueType
        {
            get { return typeof(T); }
        }
    }
