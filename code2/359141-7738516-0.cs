    void ParamMethod1 (params object[] arg)
    {
        var args = new List<object>();
        args.Add(0);
        if (arg != null)
        {
            args.AddRange(arg);
        }        
        ParamMethod2(args.ToArray());
    }
