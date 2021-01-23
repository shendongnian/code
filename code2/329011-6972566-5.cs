    [StructLayout(LayoutKind.Sequential)]
    struct SYSTEM_LOGICAL_PROCESSOR_INFORMATION
    {
        public UIntPtr ProcessorMask;
        public LOGICAL_PROCESSOR_RELATIONSHIP Relationship;
        public ProcessorRelationUnion RelationUnion;
    }
    [StructLayout(LayoutKind.Explicit)]
    struct ProcessorRelationUnion
    {
        [FieldOffset(0)] public CACHE_DESCRIPTOR Cache;
        [FieldOffset(0)] public uint NumaNodeNumber;
        [FieldOffset(0)] public byte ProcessorCoreFlags;
        [FieldOffset(0)] private UInt64 Reserved1;
        [FieldOffset(8)] private UInt64 Reserved2;
    }
    [StructLayout(LayoutKind.Sequential)]
    struct CACHE_DESCRIPTOR
    {
        public byte Level;
        public byte Associativity;
        public ushort LineSize;
        public uint Size;
        public PROCESSOR_CACHE_TYPE Type;
    }
    enum LOGICAL_PROCESSOR_RELATIONSHIP : uint
    {
        ProcessorCore = 0,
        NumaNode = 1,
        RelationCache = 2,
    }
