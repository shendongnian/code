    try
    {
        ...
    }
    catch (Exception e)
    {
        throw e.WrapInFaultException();
    }
    public static Exception WrapInFaultException(this Exception e)
    {
        var type = typeof(FaultException<>).MakeGenericType(e.GetType());
        return (Exception)Activator.CreateInstance(type, e);
    }
