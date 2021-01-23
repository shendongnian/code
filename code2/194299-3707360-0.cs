    public static object Default(Type type)
    {
       if(type.IsValueType)
       {
          return Activator.CreateInstance(type);
       }
       return null;
    }
