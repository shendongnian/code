    public delegate int parameter6(int volcnt, System.IntPtr vod);
    [StructLayout(LayoutKind.Sequential)]
    public struct csharp_firstSturct
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string parameter1;
        public int    parameter2;
        public ulong  parameter3;
        public ushort parameter4;
        public System.IntPtr  parameter5;
        public parameter6 m_parameter6;
        
        [MarshalAs(UnmanagedType.Struct)]
        public second_struct parameter7;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct second_struct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string parameter8;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string parameter9;
    }
