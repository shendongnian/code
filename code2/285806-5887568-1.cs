    public class TestClass
    {
        Property<int> _propertyInt;
        public int MyInt
        {
            get { return _propertyInt.Value; }
            set { _propertyInt.Value = value; }
        }
        Property<string> _propertyString;
        public string MyString
        {
            get { return _propertyString.Value; }
            set { _propertyString.Value = value; }
        }
    }
