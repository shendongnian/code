    public static Action<TIn, TOut> GetMapper<TIn, TOut>()
    {
        var aProperties = typeof(TIn).GetProperties();
        var bType = typeof (TOut);
        var result = from aProperty in aProperties
                     let bProperty = bType.GetProperty(aProperty.Name)
                     where bProperty != null &&
                           aProperty.CanRead &&
                           bProperty.CanWrite
                     select new { 
                                  aGetter = aProperty.GetGetMethod(),
                                  bSetter = bProperty.GetSetMethod()
                                };
        return (a, b) =>
                   {
                       foreach (var properties in result)
                       {
                           var propertyValue = properties.aGetter.Invoke(a, null);
                           properties.bSetter.Invoke(b, new[] { propertyValue });
                       }
                   };
    }
