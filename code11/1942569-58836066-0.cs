    public sealed class FwDynamicObject : DynamicObject
    {
        private readonly Dictionary<string, object> _properties;
        private readonly Dictionary<string, Type> _propertyTypes;
        public FwDynamicObject(Dictionary<string, object> properties, Dictionary<string, Type> propertyTypes = null)
        {
            _properties = properties;
            _propertyTypes = propertyTypes;
        }
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _properties.Keys;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_properties.ContainsKey(binder.Name))
            {
                result = _properties[binder.Name];
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (_properties.ContainsKey(binder.Name))
            {
                var t = GetMemberType(binder.Name);
                if (t != null)
                {
                    try
                    {
                        value = Convert.ChangeType(value, t);
                    }
                    catch(Exception e)
                    {
                        return false;
                    }
                }
                    
                _properties[binder.Name] = value;
                return true;
            }
            else
            {
                return false;
            }
        }
        private Type GetMemberType(string name)
        {
            if (_propertyTypes.ContainsKey(name))
            {
                return _propertyTypes[name];
            }
            return null;
        }
    }
