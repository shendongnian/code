    /// <remarks>
    /// Code from http://www.atalasoft.com/blogs/spikemclarty/february-2012/dynamically-testing-an-activex-control-from-c-and
    /// </remarks>
    class ActivationContext
    {
        static public void UsingManifestDo(string manifest, Action action)
        {
            UnsafeNativeMethods.ACTCTX context = new UnsafeNativeMethods.ACTCTX();
            context.cbSize = Marshal.SizeOf(typeof(UnsafeNativeMethods.ACTCTX));
            if (context.cbSize != 0x20)
            {
                throw new Exception("ACTCTX.cbSize is wrong");
            }
            context.lpSource = manifest;
            IntPtr hActCtx = UnsafeNativeMethods.CreateActCtx(ref context);
            if (hActCtx == (IntPtr)(-1))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            try // with valid hActCtx
            {
                IntPtr cookie = IntPtr.Zero;
                if (!UnsafeNativeMethods.ActivateActCtx(hActCtx, out cookie))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                try // with activated context
                {
                    action();
                }
                finally
                {
                    UnsafeNativeMethods.DeactivateActCtx(0, cookie);
                }
            }
            finally
            {
                UnsafeNativeMethods.ReleaseActCtx(hActCtx);
            }
        }
        [SuppressUnmanagedCodeSecurity]
        internal static class UnsafeNativeMethods
        {
            // Activation Context API Functions
            [DllImport("Kernel32.dll", SetLastError = true, EntryPoint = "CreateActCtxW")]
            internal extern static IntPtr CreateActCtx(ref ACTCTX actctx);
            [DllImport("Kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool ActivateActCtx(IntPtr hActCtx, out IntPtr lpCookie);
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool DeactivateActCtx(int dwFlags, IntPtr lpCookie);
            [DllImport("Kernel32.dll", SetLastError = true)]
            internal static extern void ReleaseActCtx(IntPtr hActCtx);
            // Activation context structure
            [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
            internal struct ACTCTX
            {
                public Int32 cbSize;
                public UInt32 dwFlags;
                public string lpSource;
                public UInt16 wProcessorArchitecture;
                public UInt16 wLangId;
                public string lpAssemblyDirectory;
                public string lpResourceName;
                public string lpApplicationName;
                public IntPtr hModule;
            }
        }
    }
