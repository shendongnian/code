      public static IDictionary<string, object> GetPropertiesDictionary<T>(object o)
      {
         var dictionary = new Dictionary<string, object>();
         foreach (var property in typeof(T).GetProperties())
         {
            dictionary[property.Name] = property.GetValue(o,null);
         }
         return dictionary;
      }
