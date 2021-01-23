    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
    public struct ZT_TRIG_STRUCT 
    {
        public int aSize;
        public int CameraIndex;
        public int SpotIndex;
        public int SpotType;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
        public string SpotName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=16)]
        public uint[] Dummy;
    }
