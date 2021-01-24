    private static object GetPropertyValue(this object obj, string propertyPath)
        {
            var fullPath = propertyPath.Split('.');
            for(int i = 0; i <= fullPath.Length - 1; i++)
            {
                if (obj == null) { return null; }
                var part = fullPath[i];
                Type type = obj.GetType();
                PropertyInfo propInfo = type.GetProperty(part);
                if (propInfo == null)
                {
                    //if its a list
                    if (obj.GetType().GetInterfaces().Any(
                        k => k.IsGenericType
                        && k.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
                    {
                        //convert to IList from object
                        var genericList = (IList)obj;
                        //returned the desired property
                        return genericList.Cast<dynamic>()
                            .First(p => p.PropertyName.ToLower().Equals(part.ToLower()))
                            .PropertyValue;
                    }
                    else return null;
                }
                obj = propInfo.GetValue(obj, null);
            }
            return obj;
        }
