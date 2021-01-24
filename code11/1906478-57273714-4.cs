    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class AdsClass
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public InnerStruct[] strArr = new InnerStruct[10];
    }
    struct InnerStruct
    {
        public byte bBoolTest;
        public int nIntTest;
    }
