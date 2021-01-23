    [StructLayout(LayoutKind.Explicit, Pack=1, CharSet=CharSet.Unicode)]
    public struct Inner
    {
        [FieldOffset(0)]
        public byte First;
        [FieldOffset(1)]
        public double NotFirst;
        [FieldOffset(9)]
        public DateTime WTF;
    }
