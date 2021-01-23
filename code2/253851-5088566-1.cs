    namespace ConsoleApplication1
    {
        class Program
        {
            [DllImport("project2.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool MsgEncode(string pIn, out IntPtr pOut);
            [DllImport("project2.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
            public static extern void BlockFree(IntPtr p);
            static void Main(string[] args)
            {
                IntPtr pOut;
                string msg;
                if (MsgEncode("Hello from C#", out pOut))
                    msg = Marshal.PtrToStringAuto(pOut);
                    BlockFree(pOut);
            }
        }
    }
