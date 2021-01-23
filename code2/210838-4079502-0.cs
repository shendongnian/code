    public class SomeObjectWrapper : ISomeType
    {
        Object _someObject;
        PropertyInfo _valuePropertyInfo;
        public SomeObjectWrapper(Object wrappedSomeObject)
        {
            _someObject = wrappedSomeObject;
            _valuePropertyInfo = _someObject.GetType().GetProperty("Value", System.Reflection.BindingFlags.Public);
        }
        public object Value
        {
            get { return _valuePropertyInfo.GetValue(_someObject, null); }
            set { _valuePropertyInfo.SetValue(_someObject, value, null); }
        }
    }
