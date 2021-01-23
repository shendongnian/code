    class Program
    {
        static void Main(string[] args)
        {
            MyStruct s = new MyStruct();
            s.MyUints = new int[] { 
                1, 2, 3, 4, 5, 6, 7, 8, 
                9, 10, 11, 12, 13, 14, 15, 16, 
                1, 2, 3, 4, 5, 6, 7, 8, 
                9, 10, 11, 12, 13, 14, 15, 16 };
            int[] chk = s.MyUints;
            // chk containts the proper values
        }
    }
    public unsafe struct MyStruct
    {
        public const int Count = 32; //array size const
        fixed int myUints[Count];
        public int[] MyUints
        {
            get
            {
                int[] res = new int[Count];
                fixed (int* ptr = myUints)
                {
                    Marshal.Copy(new IntPtr(ptr), res, 0, Count);
                }
                return res;
            }
            set
            {
                fixed (int* ptr = myUints)
                {
                    Marshal.Copy(value, 0, new IntPtr(ptr), Count);
                }
            }
        }
    }
