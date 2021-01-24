      using System.Linq;
      using System.Reflection;
 
      ...
      public static List<string> GetConstantNames() {
        return typeof(ClassName)
          .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
          .Where(fi => fi.IsLiteral && !fi.IsInitOnly) // constants, not readonly
          .Where(fi => fi.FieldType == typeof(string)) // of type string
          .Select(fi => fi.Name) 
          .ToList();
      } 
