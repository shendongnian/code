    public class TypedText<T>
        : TextBox 
        where T : IConvertible
    {
        public object Value
        {
            get { return Convert.ChangeType(Text, typeof(T)); }
        }
    }
