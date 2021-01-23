    private readonly Dictionary<Type, object> _items = new Dictionary<Type, object>();
        public T For<T>() where T : class
        {
            Type serviceType = typeof (T);
            lock (_items)
            {
                object instance;
                if (_items.TryGetValue(serviceType, out instance))
                    return (T) instance;
            }
            Assembly asm = Assembly.GetExecutingAssembly();
            var types = asm.GetTypes().Where(x => x.IsClass
                                                  && !x.IsAbstract
                                                  && serviceType.IsAssignableFrom(x)
                );
            T returnVar = null;
            foreach (Type x in types)
            {
                ConstructorInfo[] mi = x.GetConstructors();
                returnVar = (T) asm.CreateInstance(x.UnderlyingSystemType.ToString());
            }
            if (returnVar != null)
            {
                lock (_items)
                    _items.Add(serviceType, returnVar);
                return returnVar;
            }
            throw new Exception("No Repository for: " + typeof (T).Name);
        }
