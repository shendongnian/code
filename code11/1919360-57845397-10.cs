    public static class Extensions
    {
      public static Dictionary<string, object> ToDictionary(this object instanceToConvert)
      {
        Dictionary<string, object> resultDictionary = instanceToConvert.GetType()
          .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
          .Where(propertyInfo => !propertyInfo.GetIndexParameters().Any())
          .ToDictionary(
            propertyInfo => propertyInfo.Name,
            propertyInfo => Extensions.ConvertPropertyToDictionary(propertyInfo, instanceToConvert));
        resultDictionary.Add("IsCollection", false);
        return resultDictionary;
      }
    
      private static object ConvertPropertyToDictionary(PropertyInfo propertyInfo, object owner)
      {
        Type propertyType = propertyInfo.PropertyType;
        object propertyValue = propertyInfo.GetValue(owner);
        if (propertyValue is Type)
        {
          return propertyValue;
        }
    
        // If property is a collection don't traverse collection properties but the items instead
        if (!propertyType.Equals(typeof(string)) && typeof(IEnumerable).IsAssignableFrom(propertyType))
        {
          var items = new Dictionary<string, object>();
          var enumerable = propertyInfo.GetValue(owner) as IEnumerable;
          int index = 0;
          foreach (object item in enumerable)
          {
            // If property is a string stop traversal
            if (item.GetType().IsPrimitive || item is string)
            {
              items.Add(index.ToString(), item);
            }
            else if (item is IEnumerable enumerableItem)
            {
              items.Add(index.ToString(), ConvertIEnumerableToDictionary(enumerableItem));
            }
            else
            {
              Dictionary<string, object> dictionary = item.ToDictionary();
              items.Add(index.ToString(), dictionary);
            }
    
            index++;
          }
    
          items.Add("IsCollection", true);
          items.Add("Count", index);
          return items;
        }
    
        // If property is a string stop traversal
        if (propertyType.IsPrimitive || propertyType.Equals(typeof(string)))
        {
          return propertyValue;
        }
    
        PropertyInfo[] properties =
          propertyType.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
        if (properties.Any())
        {
          Dictionary<string, object> resultDictionary = properties.ToDictionary(
            subtypePropertyInfo => subtypePropertyInfo.Name,
            subtypePropertyInfo => propertyValue == null
              ? null
              : (object) Extensions.ConvertPropertyToDictionary(subtypePropertyInfo, propertyValue));
          resultDictionary.Add("IsCollection", false);
          return resultDictionary;
        }
    
        return propertyValue;
      }
    
      private static Dictionary<string, object> ConvertIEnumerableToDictionary(IEnumerable enumerable)
      {
        var items = new Dictionary<string, object>();
        int index = 0;
        foreach (object item in enumerable)
        {
          // If property is a string stop traversal
          if (item.GetType().IsPrimitive || item is string)
          {
            items.Add(index.ToString(), item);
          }
          else
          {
            Dictionary<string, object> dictionary = item.ToDictionary();
            items.Add(index.ToString(), dictionary);
          }
    
          index++;
        }
    
        items.Add("IsCollection", true);
        items.Add("Count", index);
        return items;
      }
    }
