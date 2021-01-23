    [DllImport(
        "TradeEngine.dll",
        CharSet = CharSet.Ansi,
        CallingConvention = CallingConvention.Cdecl,
        ExactSpelling = true),
        SuppressUnmanagedCodeSecurity]
    public static extern void Mafonc([MarshalAs(UnmanagedType.LPStr)]string nom);
