    protected void CallBaseCtor(params object[] args)
    {
        GetType().BaseType
            .GetConstructor(args.Select(a => a.GetType()).ToArray())
            .Invoke(this, args);
    }
