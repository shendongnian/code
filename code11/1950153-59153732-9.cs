      private static void SaveToFile<T>(IEnumerable<T> source, string fileName) {
        HashSet<Type> allowedTypes = new HashSet<Type>() {
          typeof(string), typeof(int), typeof(decimal), typeof(double)
        };
        var properties = typeof(T)
          .GetProperties(BindingFlags.Instance | BindingFlags.Public)
          .Where(prop => prop.CanRead && prop.CanWrite)
          .Where(prop => !prop.GetIndexParameters().Any())
          .Where(prop => allowedTypes.Contains(prop.PropertyType))
       // .Where(prop => ...) // Add here more coditions if required
          .ToArray();
        File.WriteAllLines(fileName, source
          .Select(item => string.Join(",", properties
            .Select(property => property.GetValue(item))))); 
      } 
