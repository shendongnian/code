        public class ValidationRulesParam
    {
        private readonly Dictionary<string, object> _parameters = new Dictionary<string, object>();
        public bool AddParam(string name, object value)
        {
            if (!_parameters.ContainsKey(name))
                return false;
            _parameters.Add(name, value);
            return true;
        }
        public bool IsTypedParameterSet(string name, Type valueType)
        {
            object value;
            if (_parameters.TryGetValue(name, out value) == false)
                return false;
            return (value.GetType() == valueType);
        }
        public TValue GetParamValue<TValue>(string name)
        {
            object value;
            if (_parameters.TryGetValue(name, out value) == false)
                return default(TValue);
            if (!(value is TValue))
                return default(TValue);
            return (TValue)value;
        }
        public object this[string name]
        {
            get { return GetParamValue<object>(name); }
            set { AddParam(name, value); }
        }
    }
