    [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
    public delegate void rdOnAllDoneCallbackDelegate(int parameter);
    
    [DllImport("sb6lib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int rdOnAllDone(rdOnAllDoneCallbackDelegate callback);
