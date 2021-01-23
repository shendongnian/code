    MemoryStream ms = new MemoryStream(headerData);
    AsfFileHeader asfFileHeader = ReadStruct<AsfFileHeader>(ms);
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    internal struct AsfFileHeader
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)] 
        public byte[] object_id;
        public UInt64 object_size;
        public UInt32 header_object_count;
        public byte r1;
        public byte r2;
    }
