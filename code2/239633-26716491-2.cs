    [StructLayout(LayoutKind.Explicit)]
    private struct DoubleULong
    {
        [FieldOffset(0)]
        public double Double;
        [FieldOffset(0)]
        public readonly ulong ULong;
    }
    bool IsNegative(double value)
    {
        var du = new DoubleULong { Double = value };
        return ((du.ULong >> 62) & 2) == 2;
    }
