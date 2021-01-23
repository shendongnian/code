    using LPWORD = System.IntPtr;
    using LPVOID = System.IntPtr;
    
    [DllImport("foo.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern LPVOID extFunc(LPWORD lpdwMandatory,__arglist);
