    [DllImport("NativeDLL", EntryPoint="SetupCallback", CallingConvention = CallingConvention.Cdecl)] 
    public static extern void SetupCallback_Base(BaseCallbackFunc callback);
    [DllImport("NativeDLL", EntryPoint="SetupCallback", CallingConvention = CallingConvention.Cdecl)] 
    public static extern void SetupCallback_Concrete1(Concrete1CallbackFunc callback);
    [DllImport("NativeDLL", EntryPoint="SetupCallback", CallingConvention = CallingConvention.Cdecl)] 
    public static extern void SetupCallback_Concrete2(Concrete2CallbackFunc callback);
