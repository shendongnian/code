    [DllImport("Dll1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "ZBNConnect")]
    extern static int ZBNConnect1(...)
    [DllImport("Dll2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "ZBNConnect")]
    extern static int ZBNConnect2(...)
    
    public static int ZBNConnect(...)
    {
        if (UseDll1)
            return ZBNConnect1(...);
       return ZBNConnect2(...);
    }
