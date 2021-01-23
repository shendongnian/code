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
