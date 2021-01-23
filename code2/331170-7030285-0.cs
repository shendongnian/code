    struct ExampleStruct
    {
        public UInt64 field1;
        public UInt32 field2;
        public UInt16 field3;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        public byte[] field4;
    }
