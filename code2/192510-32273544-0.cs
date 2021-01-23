    public static void SetNestedPropertyValue(object obj, string property,object value)
            {
                if (obj == null)
                    throw new ArgumentNullException("obj");
    
                if (string.IsNullOrEmpty(property))
                    throw new ArgumentNullException("property");
    
                var propertyNames = property.Split('.');
    
                foreach (var p in propertyNames)
                {
                    
                    Type type = obj.GetType();
                    PropertyInfo info = type.GetProperty(p);
                    if (info != null)
                    {
                        info.SetValue(obj, value);
                        return;
                    }
    
                }
    
                throw new KeyNotFoundException("Nested property could not be found.");
            }
