    public static class PropertyValueHelper
    {
         public static IEnumerable<string> GetPropertyValues(object source)
         { 
              Type t = source.GetType();
              foreach (var property in t.GetProperties())
              {
                   object value = property.GetValue(source, null);
                   if (value != null)
                   {
                        yield return property.Name + "=" + value.ToString();
                   }
                   else
                   {
                        yield return property.Name + "=";  
                   }
              }
         } 
    }
