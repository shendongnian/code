    public static class Traversal
    {
        public static void TraverseThroughClass<T>(T entity) where T : class
        {
            var type = typeof(T);
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType))
                {
                    var propertiesValues = prop.GetValue(entity);
                    // What if the property value is null?
                    if (propertiesValues == null) continue;
                    var collection = propertiesValues as IEnumerable;
                    foreach (var listItem in collection)
                    {
                        // I don't know what you want to do with these. 
                        // I'm just confirming that we're able to inspect them.
                        Debug.WriteLine("Success, we're iterating over the items!!"); 
                    }
                }
                else
                {
                    Debug.WriteLine("Prop Name : " + prop.Name + " Prop Value : "
                                      + prop.GetValue(entity, null));
                }
            }
        }
    }
