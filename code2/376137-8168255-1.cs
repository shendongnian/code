    internal class FirstDllSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private MySafeFileHandle()
            : base(true)
        {
        }
        override protected bool ReleaseHandle()
        {        
            return NativeMethods.FirstDll_OBJECT_FREE(handle);
        }
    }
    internal class NativeMethods
    {
        [DllImport("whatever.dll")]
        public static extern void FirstDll_OBJECT_FREE(FirstDllSafeHandle handle);
        [DllImport("whatever.dll")]
        public static extern void FirstDll_GetObject(out FirstDllSafeHandle handle);
        [DllImport("whatever.dll")]
        public static extern void SecondDll_OBJECT_FREE(SecondDllSafeHandle handle);
        [DllImport("whatever.dll")]
        public static extern void SecondDll_GetObject(out SecondDllSafeHandle handle);
    }
