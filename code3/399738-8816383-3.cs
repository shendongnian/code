    private static IEnumerable<PropertyInfo> FindProperties(object objectTree, Type targetType)
        {
            if (targetType.IsAssignableFrom(objectTree.GetType()))
            {
                var properties = objectTree.GetType().GetProperties();
                foreach (var property in properties)
                {
                    yield return property;
                    if (targetType.IsAssignableFrom(property.PropertyType))
                    {
                        object instance = property.GetValue(objectTree, null);
                        foreach (var subproperty in FindProperties(instance, targetType))
                        {
                            yield return subproperty;
                        }
                    }
                }
            }
        }
