    public static int GetPropertiesMaxLength(object obj) {
      int totalMaxLength=0;
      Type type = obj.GetType();
      PropertyInfo[] info = type.GetProperties();
      foreach (PropertyInfo property in info) {
         if (property.PropertyType == typeof(string)) {
           string value = property.GetValue(obj, null) as string;
           totalMaxLength += value.Length;
        }
      }
      return totalMaxLength;
    }
