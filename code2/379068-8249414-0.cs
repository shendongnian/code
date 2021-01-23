    [StructLayout(LayoutKind.Sequential)]
    public struct TestType
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
        public TestRecord[] MyTestRecords;
        [MarshalAs(UnmanagedType.I1)]
        public TestEnum MyTestEnum;
    }
