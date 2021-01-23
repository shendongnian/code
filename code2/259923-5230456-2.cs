    [StructLayout(LayoutKind.Sequential)]
    public struct SnapRoundingOption
    {
        public double PixelSize;
        [MarshalAs(UnmanagedType.U1)]
        public bool IsISR;
        [MarshalAs(UnmanagedType.U1)]
        public bool IsOutputInteger;
        public int KdTrees;
    }
