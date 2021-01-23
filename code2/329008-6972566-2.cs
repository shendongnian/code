    [StructLayout(LayoutKind.Sequential)]
    struct CACHE_DESCRIPTOR
    {
       public byte Level;
       public byte Associativity;
       public ushort LineSize;
       public uint Size;
       public PROCESSOR_CACHE_TYPE Type;
    }
    
    enum PROCESSOR_CACHE_TYPE
    {
        Unified = 0,
        Instruction = 1,
        Data = 2,
        Trace = 3,
    }
