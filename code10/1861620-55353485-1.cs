    using System.Reflection;
    ...
    private static T PropertyReader<T>(object value, string name) {
      if (null == value)
        throw new ArgumentNullException(nameof(value));
      else if (null == name)
        throw new ArgumentNullException(nameof(name));
      var prop = value.GetType().GetProperty(name);
      if (null == prop || !prop.CanRead)
        throw new ArgumentException($"property {name} has not been found.", nameof(name));
      return (T)(Convert.ChangeType(prop.GetValue(value, new object[0]), typeof(T)));
    }
