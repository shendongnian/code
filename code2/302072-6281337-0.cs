    static void MyAction() {}
    static Action DelegateCache = null;
    ...
    for(i = 0; i < 10; ++i)
    {
        if (C.DelegateCache == null) C.DelegateCache = new Action ( C.MyAction )
        M(C.DelegateCache);
    }
