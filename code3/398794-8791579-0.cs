    interface IField
    {
        object Value { get; set; }
    }
    interface IField<T> : IField
    {
        new T Value { get; set; }
    }
    abstract class BaseField<T> : IField<T>
    {
        T _value;
        public T Value
        {
            get { return _value; }
            set
            {
                // could add stuff like OnValueChanging, IsValueValid, etc...
                this._value = value;
            }
        }
        object IField.Value
        {
            get { return Value; }
            set { Value = (T)value; }
        }
    }
    class DynamicObject : List<IField>
    {
        public TField GetField<TField>() where TField : IField
        {
            return this.OfType<TField>().Single();
        }
    }
