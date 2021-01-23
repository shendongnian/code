    IList<Type> types = TypeFinder.GetImplementors(typeof(IHandler<>));
    foreach (Type type in types)
    {
        Type[] typeArgs = { typeof(IEvent) };
        var t = type.MakeGenericType(typeArgs);
        object instance = Activator.CreateInstance(t);
        Listeners.Register((IHandler<IEvent>)instance);
    }
