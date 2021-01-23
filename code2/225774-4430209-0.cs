    public class PropertyWrapper<T>
    {
        private Dictionary<string, Methods> _properties = new Dictionary<string, Methods>();
        private class Methods
        {
            public MethodBase Get { get; set; }
            public MethodBase Set { get; set; }
        }
        public PropertyWrapper()
        {
            foreach (var item in typeof(T).GetProperties())
            {
                if (!item.CanRead && !item.CanWrite)
                    continue;
                var mappings = new Methods();
                if (item.CanRead)
                    mappings.Get = item.GetGetMethod();
                if (item.CanWrite)
                    mappings.Set = item.GetSetMethod();
                _properties.Add(item.Name, mappings);
            }
        }
        public object GetValue(T instance, string name)
        {
            Methods mappings;
            if (_properties.TryGetValue(name, out mappings) && mappings.Get != null)
                return mappings.Get.Invoke(instance, null);
            throw new MappingException("Specified property cannot be read", typeof(T), name);
        }
        public void SetValue(T instance, string name, object value)
        {
            Methods mappings;
            if (_properties.TryGetValue(name, out mappings) && mappings.Set != null)
            {
                mappings.Set.Invoke(instance, new[] { value });
                return;
            }
            throw new MappingException("Specified property cannot be written.", typeof(T), name);
        }
    }
    public class MappingException : Exception
    {
        public MappingException(string errMsg, Type type, string propertyName) 
            : base(errMsg)
        {
            ReflectedType = type;
            PropertyName = propertyName;
        }
        public Type ReflectedType { get; private set; }
        public string PropertyName { get; private set; } 
    }
