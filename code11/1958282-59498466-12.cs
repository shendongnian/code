      using System.Linq;
      using System.Reflection;
      using System.Text.RegularExpressions;
      ...
      Dictionary<string, object> result = testTuple
        .GetType()
        .GetProperties()
        .Where(prop => prop.CanRead)
        .Where(prop => !prop.GetIndexParameters().Any())
        .Where(prop => Regex.IsMatch(prop.Name, "^Item[0-9]+$"))
        .ToDictionary(prop => prop.Name, prop => prop.GetValue(testTuple));
