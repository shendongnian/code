      public static Dictionary<string, string> GetConstantNamesAndValues() {
        return typeof(ClassName)
          .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
          .Where(fi => fi.IsLiteral && !fi.IsInitOnly) // constants, not readonly
          .Where(fi => fi.FieldType == typeof(string)) // of type string
          .ToDictionary(fi => fi.Name, fi => fi.GetValue(null) as String); 
      } 
