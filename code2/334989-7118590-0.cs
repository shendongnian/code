    private void SetProperties<T>(List<T> objects, List<Tuple<string, object>> propsAndValues) where T:<your_class>
            {
                Type type = typeof(T);
                var propInfos = propsAndValues.ToDictionary(key => type.GetProperty(key.Item1, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.SetProperty), elem => elem.Item2);
    
                objects.AsParallel().ForAll(obj =>
                    {
                        obj.SetProps(propInfos);                                  
                    });
    
            }
    
    public static void SetProps<T>(this T obj, Dictionary<PropertyInfo, object> propInfos) where T : <your_class>
            {
                foreach (var propInfo in propInfos)
                {
                    propInfo.Key.SetValue(obj, propInfo.Value, null);
                }            
            }
