    public interface ISPParameter
    {
        string Name { get; }
        object Value { get; }
    }
    public class TypedText<T>
        : TextBox, ISPParameter
        where T : IConvertible
    {
        private string parameterName;
        public TypedText(string parameterName)
        {
            this.parameterName = parameterName;
        }
        public object TypedValue
        {
            get { return Convert.ChangeType(Text, typeof(T)); }
        }
        string ISPParameter.Name
        {
            get { return parameterName; }
        }
        object ISPParameter.Value
        {
            get { return TypedValue; }
        }
    }
