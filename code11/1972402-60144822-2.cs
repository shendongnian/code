    [StructLayout(LayoutKind.Explicit)]
    public struct Mapper
    {
       [FieldOffset(0)] public UInt64 Combined;
       [FieldOffset(1)] public UInt16 Short0;
       [FieldOffset(2)] public UInt16 Short1;
       [FieldOffset(3)] public UInt16 Short2;
       [FieldOffset(4)] public UInt16 Short3;
    }
