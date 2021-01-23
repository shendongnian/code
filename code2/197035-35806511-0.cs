        using System.Runtime.InteropServices;
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void UNMANAGED_CALLBACK();
        public void Crash()
        {
            var crash = (UNMANAGED_CALLBACK)Marshal.GetDelegateForFunctionPointer((IntPtr) 123, typeof(UNMANAGED_CALLBACK));
            crash();
        }
