    public TBase GetData<TBase>(TBase type) where TBase : IBase
    {
        if (typeof(A).IsAssignable(typeof(TBase)))
        {
            // Do the special case stuff
        }
        ...
    }
