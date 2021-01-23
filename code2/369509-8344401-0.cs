    PropertyInfo prop = entity.GetType().BaseType.GetProperty(newValue.Key, BindingFlags.Public | BindingFlags.Instance);
    var typedValue = TypeDescriptor.GetConverter(prop.PropertyType).ConvertFrom(newValue.Value);
            					if (null != prop && prop.CanWrite)
            					{
            						prop.SetValue(entity, typedValue, null);        					}
