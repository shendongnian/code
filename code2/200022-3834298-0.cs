    T Get<T>(int id) where T : EntityBase
    {
        Type context = Context.GetType();
        MethodInfo getMethod = context.GetMethod("Get", BindingFlags.Public);
        MethodInfo genericGet = getMethod.MakeGenericMethod(new [] {typeof(T)});
        return (T)genericGet.Invoke(Context, new object[] { id } );
    }
