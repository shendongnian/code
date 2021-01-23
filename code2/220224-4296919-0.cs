    [StructLayout(LayoutKind.Explicit)]
    public struct Pixel
    {
        // These fields provide access to the individual
        // components (A, R, G, and B), or the data as
        // a whole in the form of a 32-bit integer
        // (signed or unsigned). Raw fields are used
        // instead of properties for performance considerations.
        [FieldOffset(0)]
        public int Int32;
        [FieldOffset(0)]
        public uint UInt32;
        [FieldOffset(0)]
        public byte Blue;
        [FieldOffset(1)]
        public byte Green;
        [FieldOffset(2)]
        public byte Red;
        [FieldOffset(3)]
        public byte Alpha;
        // Converts this object to/from a System.Drawing.Color object.
        public Color Color {
            get {
                return Color.FromArgb(Int32);
            }
            set {
                Int32 = Color.ToArgb();
            }
        }
    }
