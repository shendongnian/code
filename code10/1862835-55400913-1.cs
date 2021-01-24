    public struct Example1Struct
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string StationName;
        public UInt16 IdCode;
        [MarshalAs(UnmanagedType.LPArray)]
        public AnotherStruct[] OtherStructs;
    }
