        public T AllReturnTags<T>() => (T)AllReturnTags(typeof(T));
        public object AllReturnTags(Type type)
        {
            var newObj = Activator.CreateInstance(type); // create new instance of your target class
            
            Func<PropertyInfo, bool> query = q
                 => q.PropertyType.IsClass &&         
                    q.CanWrite;                  
            foreach (var el in type.GetProperties().Where(query))
            {
                // create new instance of el cascade
                if (el.PropertyType == typeof(string))
                {
                    el.SetValue(newObj, "", null);
                }
                if (el.PropertyType == typeof(Int32))
                {
                    el.SetValue(newObj, 0, null);
                }
                if (el.PropertyType.IsClass && el.PropertyType != typeof(string) && el.PropertyType != typeof(Int32) && el.PropertyType.IsGenericType == true && el.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var elInstance = AllReturnTags(el.PropertyType);
                    Type itemType = typeof(List<>).MakeGenericType(elInstance.GetType());
                    IList res = (IList)Activator.CreateInstance(itemType);
                    res.Add(elInstance);
                    try { el.SetValue(newObj, res, null); } catch {  };
                }
                if (el.PropertyType.IsClass && el.PropertyType != typeof(string) && el.PropertyType != typeof(Int32) && el.PropertyType.IsGenericType != true )
                {
                    var elInstance = AllReturnTags(el.PropertyType);
                    try { el.SetValue(newObj, elInstance, null); } catch { return elInstance; };
                }
            }
            return newObj;
        }
