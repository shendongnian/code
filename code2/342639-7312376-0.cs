    [StructLayout(LayoutKind.Explicit)]
    public struct Color
    {
        [FieldOffset(0)] public int Raw;
        [FieldOffset(0)] public byte Black;
        [FieldOffset(8)] public byte Green;
        [FieldOffset(16)] public byte Red;
        [FieldOffset(24)] public byte Alpha;
    }
