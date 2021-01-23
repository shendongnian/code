    IList<Type> types = TypeFinder.GetImplementors(typeof(IHandler<IEvent>));
    foreach (Type type in types)
    {
        object instance = Activator.CreateInstance(type);
        Listeners.Register((IHandler<IEvent>)instance);
    }
