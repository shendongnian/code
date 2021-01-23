    [System.Runtime.InteropServices.StructLayout(LayoutKind.Explicit)]
    struct TestUnion
    {
        [System.Runtime.InteropServices.FieldOffset(0)]
        public int i;
    
        [System.Runtime.InteropServices.FieldOffset(0)]
        public double d;
    
        [System.Runtime.InteropServices.FieldOffset(0)]
        public char c;
    
        [System.Runtime.InteropServices.FieldOffset(0)]
        public byte b;
    }
