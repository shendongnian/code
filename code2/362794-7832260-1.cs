    [StructLayout(LayoutKind.Explicit)]
    struct UnionArray
    {
        [FieldOffset(0)]
        public byte[] Bytes;
    
        [FieldOffset(0)]
        public double[] Doubles;
    }
    static void Main(string[] args)
    {
        // From bytes to floats - works
        byte[] bytes = { 0, 1, 2, 4, 8, 16, 32, 64 };
        UnionArray arry = new UnionArray { Bytes = bytes };
   
        for (int i = 0; i < arry.Bytes.Length / 8; i++)
            Console.WriteLine(arry.Doubles[i]);   
    }
