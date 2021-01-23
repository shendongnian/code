    [StructLayout(LayoutKind.Explicit)]
    struct UnionArray
    {
        [FieldOffset(0)]
        public Byte[] Bytes;
        [FieldOffset(0)]
        public short[] Shorts;
    }
        
    static void Main(string[] args)
    {
        var union = new UnionArray() {Bytes = new byte[1024]};
        foreach (short s in union.Shorts)
        {
            Console.WriteLine(s);
        }
    }
