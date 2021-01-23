    [StructLayout(LayoutKind.Sequential)]
    [MarshalAs(UnmanagedType.ByValArray)]      
    public struct ABS_BIR
    {
        public ABS_BIR_HEADER Header;   // BIR header
    
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2560)]
        public byte[] Data;     // The data composing the fingerprint template.
    }
