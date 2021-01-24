      using System.Linq;
      using System.Reflection;
      ...
      HashSet<Type> allowedTypes = new HashSet<Type>() {
        typeof(string), typeof(int), typeof(decimal), typeof(double)
      };
      var properties = typeof(Car)
        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
        .Where(prop => prop.CanRead && prop.CanWrite)
        .Where(prop => !prop.GetIndexParameters().Any())
        .Where(prop => allowedTypes.Contains(prop.PropertyType))
        .ToArray();
