    [StructLayout(LayoutKind.Sequential)]
    internal struct X
    {
        public int IntValue;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.U1)] 
        public byte[] Array;
    }
    static void Main(string[] args)
    {
        byte[] data = {1, 0, 0, 0, 9, 8, 7}; // IntValue = 1, Array = {9,8,7}
        IntPtr ptPoit = Marshal.AllocHGlobal(data.Length);
        Marshal.Copy(data, 0, ptPoit, data.Length);
        var x = (X) Marshal.PtrToStructure(ptPoit, typeof (X));
        Marshal.FreeHGlobal(ptPoit);
        Console.WriteLine("x.IntValue = {0}", x.IntValue);
        Console.WriteLine("x.Array = ({0}, {1}, {2})", x.Array[0], x.Array[1], x.Array[2]);
    }
