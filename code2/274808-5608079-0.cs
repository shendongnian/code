    class NativeMethods
    {
        [DllImport("Monkey.dll", CallingConvention=CallingConvention.CDecl)]
        public static extern void FastMonkey();
    }
