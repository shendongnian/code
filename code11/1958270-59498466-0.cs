      using System.Linq;
      using System.Reflection;
      using System.Text.RegularExpressions;
      ...
      Dictionary<string, object> result = tuple
        .GetType()
        .GetProperties()
        .Where(prop => Regex.IsMatch(prop.Name, "^Item[0-9]+$"))
        .ToDictionary(prop => prop.Name, prop => prop.GetValue(tuple));
