    private static readonly ArrayMethod = typeof(NameOfContainingType)
        .GetMethod("GenericArrayFunction", BindingFlags.Static | BindingFlags.NonPublic);
    ...
    static T GenericFunction<T>(T t)
    {
           if (t == null) return default(T);
    
           if (t is Array)
           {
               Type elementType = t.GetType().GetElementType();
               MethodInfo method = ArrayMethod.MakeGenericMethod(new[] elementType);
               return (T) method.Invoke(null, new object[] { t });
           }
           ...
    }
