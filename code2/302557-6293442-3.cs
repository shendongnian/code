    /// <summary>
    /// Simple attribute class for storing String Values
    /// </summary>
    public class StringValueAttribute : Attribute
    {
        public string Value { get; private set; }
        public StringValueAttribute(string value)
        {
            Value = value;
        }
    }
