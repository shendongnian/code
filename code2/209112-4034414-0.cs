    public object GetProperty(object obj, string propertyName)
    {
      PropertyInfo pi = obj.GetType().GetProperty(propertyName);
      object value = pi.GetValue(o, null);
      //or object value = pi.GetGetMethod().Invoke(obj, null)
      return value;
    }
