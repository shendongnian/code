    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MyStruct
    {
        public ushort First;
        public ushort Second;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string MyString;
    }
