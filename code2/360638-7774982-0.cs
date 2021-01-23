    public class StringWrapper
    {
        public StringWrapper(string s)
        {
            Value = s;
        }
        public string Value { get { return _value; } set { _value = value; } }
        string _value;
    }
