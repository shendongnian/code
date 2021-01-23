    static Func<Ectx, Sctx> __get = arg =>
    {
        // Hijack the first caller to do initialization...
        var fi = typeof(Ectx).GetField(
            "_syncContext",                         // private field in 'ExecutionContext'
            BindingFlags.NonPublic|BindingFlags.Instance);
        var dm = new DynamicMethod(
            "foo",                                  // (any name)
            typeof(Sctx),                           // getter return type
            new[] { typeof(Ectx) },                 // type of getter's single arg
            typeof(Ectx),                           // "owner" type
            true);                                  // allow private field access
        var il = dm.GetILGenerator();
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldfld, fi);
        il.Emit(OpCodes.Ret);
        // ...now replace ourself...
        __get = (Func<Ectx, Sctx>)dm.CreateDelegate(typeof(Func<Ectx, Sctx>));
        // oh yeah, don't forget to handle the first caller's request
        return __get(arg);                 //  ...never to come back here again. SAD!
    };
