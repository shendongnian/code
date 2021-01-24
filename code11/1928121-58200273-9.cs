    private static string MakeResponse(IEnumerable<object> context, string name) {
      if (string.IsNullOrEmpty(name))
        return "???";
      else if (context == null)
        return "???";
      string[] items = name.Split('.');
      string className = items[0];
      string propertyName = items.Length > 1 ? items[1] : null;
      object data = context
        .FirstOrDefault(item => 
           string.Equals(item.GetType().Name, className, StringComparison.OrdinalIgnoreCase));
      if (null == data)
        return "???";
      if (null == propertyName)
        return data.ToString();
      var property = data
        .GetType()
        .GetProperties(BindingFlags.Public | 
                       BindingFlags.Instance | 
                       BindingFlags.Static)
        .Where(prop => string.Equals(prop.Name, propertyName, StringComparison.OrdinalIgnoreCase))
        .Where(prop => prop.CanRead)
        .Where(prop => !prop.GetIndexParameters().Any())
        .FirstOrDefault();
      if (null == property)
        return "???";
      return property.GetValue(property.GetGetMethod().IsStatic ? null : data)?.ToString() ?? "";
    }
