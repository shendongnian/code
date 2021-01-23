    public static class ReflectionHelper
    {
          public static T CreateFrom<T,U>( U from )
              where T : class, new
              where U : class
          {
                var to = Activator.CreateInstance<T>();
                var toType = typeof(T);
                var fromType = typeof(U);
                foreach (var toProperty in toType.GetProperties())
                {
                    var fromProperty = fromType.GetProperty( toProperty.Name );
                    if (fromProperty != null)
                    {
                       toProperty.SetValue( to, fromProperty.GetValue( from, null), null );
                    }
                }
                return to;
          }
