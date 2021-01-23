    public static Exception On<T>(this Exception e, Action<T> action)
    {
        if(e is T)
            action((T)e);
            
        return e;
    }
    exception.
        On<ValidationException>(e => exceptionMessage.Append(e.InnerException.Message)).
        On<DomainInternalMessageException>(e => ...);
