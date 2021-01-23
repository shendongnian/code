    private static IEnumerable<PropertyInfo> FindProperties(object objectTree, Type targetType)
    {
         if (objectTree.GetType().IsAssignableFrom(targetType))
         {
              var properties = objectTree.GetType().GetProperties();
              foreach (var property in properties)
              {
                   yield return property;
    
                   if(property.PropertyType.IsAssignableFrom(targetType))
                   {
                       object instance = property.GetValue(objectTree, null);
                       foreach(var subproperty in FindProperties(instance, targetType))
                       {
                            yield return property;
                       }
                   }
              }
          }
    }
