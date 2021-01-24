    private IEnumerable<PropertyInfo> GetProperties(Type type)
    {
        PropertyInfo[] properties = type.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            if ( property.PropertyType.GetInterfaces()
                   .Any(x => x == typeof(IList)))
            {
    			 foreach(var prop in GetProperties(property.PropertyType.GetGenericArguments()[0]))
    			 	yield return prop;
            }
            else
            {
                if (property.PropertyType.Assembly == type.Assembly)
                {
                    if (property.PropertyType.IsClass)
                    {
    					yield return property;
                    }
                    GetProperties(property.PropertyType);
                }
                else
                {
    				yield return property;
                }
            }
        }
    }
