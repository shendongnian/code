    public static T To<T>(this IConvertible obj)
    {
      return (T)Convert.ChangeType(obj, typeof(T));
    }
    
    Public void Foo(object obj,string propertyName,object value)
    {
        Type t= obj.GetType().GetProperty(propName).PropertyType;
        obj.GetType().GetProperty(propName).SetValue(obj, value.To<t>(), null);
    }
