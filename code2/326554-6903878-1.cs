    [StructLayout(LayoutKind.Explicit)]
    struct UnionArray
    {
        [FieldOffset(0)]
        public Byte[] Bytes;
    
        [FieldOffset(0)]
        public float[] Floats;
    }
    
    static void Main(string[] args)
    {
        // From bytes to floats - works
        byte[] bytes = { 0, 1, 2, 4, 8, 16, 32, 64 };
        UnionArray arry = new UnionArray { Bytes = bytes };
        for (int i = 0; i < arry.Bytes.Length / 4; i++)
            Console.WriteLine(arry.Floats[i]);
    }
