    public T Clone(T what)
    {
        var castWhat = what as RunProperties;
        if(castWhat != null)
            return castWhat.Clone();
    }
