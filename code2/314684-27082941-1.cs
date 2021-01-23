    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NameRecord
    {
        public UInt16 uPlatformID;
        public UInt16 uEncodingID;
        public UInt16 uLanguageID;
        public UInt16 uNameID;
        public UInt16 uStringLength;
        public UInt16 uStringOffset; //from start of storage area
    }
