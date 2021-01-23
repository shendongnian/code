    public interface IFormDataType
    {
        object Value { get; }
    
        Type PrimitiveType { get; }
    
        string Format();
    }
    
    public abstract class FormDataType<T> : IFormDataType
    {
        object IFormDataType.Value { get { return Value; } }
        public Type PrimitiveType { get { return typeof(T); } }
        public T Value { get; private set; }
    
        public FormDataType(T value)
        {
            Value = value;
        }
    
        public abstract string Format();
    
        public override string ToString()
        {
            return Format();
        }
    }
    
    public class Currency : FormDataType<decimal>
    {
        public Currency(decimal value)
            : base(value)
        {
            //perform any validation if necessary
        }
    
        public override string Format()
        {
            return Value.ToString("C");
        }
    
        public static Currency Parse(string s)
        {
            return new Currency(decimal.Parse(s, NumberStyles.Currency));
        }
    }
