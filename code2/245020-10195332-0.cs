    [DllImport(LIB_GVC, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr gvContext();
    [DllImport(LIB_GVC, CallingConvention = CallingConvention.Cdecl)]
    public static extern int gvFreeContext(IntPtr gvc);
    ...
