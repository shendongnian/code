    public static class Extensions
    {
      public static Dictionary<string, object> ToDictionary(this object instanceToConvert)
      {
        return instanceToConvert.GetType()
          .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
          .ToDictionary(
          propertyInfo => propertyInfo.Name,
          propertyInfo => Extensions.ConvertPropertyToDictionary(propertyInfo, instanceToConvert));
    
      }
    
      private static object ConvertPropertyToDictionary(PropertyInfo propertyInfo, object owner)
      {
        Type propertyType = propertyInfo.PropertyType;
        object propertyValue = propertyInfo.GetValue(owner);
    
        // If property is a collection don't traverse collection properties but the items instead
        if (!propertyType.Equals(typeof(string)) && (typeof(ICollection<>).Name.Equals(propertyValue.GetType().BaseType.Name) || typeof(Collection<>).Name.Equals(propertyValue.GetType().BaseType.Name)))
        {
          var collectionItems = new List<Dictionary<string, object>>();
          var count = (int) propertyType.GetProperty("Count").GetValue(propertyValue);
          PropertyInfo indexerProperty = propertyType.GetProperty("Item");
          // Convert collection items to dictionary
          for (var index = 0; index < count; index++)
          {
            object item = indexerProperty.GetValue(propertyValue, new object[] { index });
            PropertyInfo[] itemProperties = item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
    
            if (itemProperties.Any())
            {
              Dictionary<string, object> dictionary = itemProperties
                .ToDictionary(
                  subtypePropertyInfo => subtypePropertyInfo.Name,
                  subtypePropertyInfo => Extensions.ConvertPropertyToDictionary(subtypePropertyInfo, item));
              collectionItems.Add(dictionary);
            }
          }
    
          return collectionItems;
        }
    
        // If property is a string stop traversal (ignore that string is a char[])
        if (propertyType.IsPrimitive || propertyType.Equals(typeof(string)))
        {
          return propertyValue;
        }
    
        PropertyInfo[] properties = propertyType.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
        if (properties.Any())
        {
          return properties.ToDictionary(
                              subtypePropertyInfo => subtypePropertyInfo.Name, 
                              subtypePropertyInfo => (object) Extensions.ConvertPropertyToDictionary(subtypePropertyInfo, propertyValue));
        }
    
        return propertyValue;
      }
    }
