    public static void CreateDirectory(string myDirectory)
        {
            SafeTokenHandle safeTokenHandle;
            bool returnValue = LogonUser(@Username, @Domain, @Password, 2, 0, out safeTokenHandle);
            if (returnValue == true)
            {
                WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle());
                using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
                {
                    System.IO.Directory.CreateDirectory(myDirectory);
                }
            }
        }
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
            int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);
        public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            private SafeTokenHandle()
                : base(true)
            {
            }
            [DllImport("kernel32.dll")]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            [SuppressUnmanagedCodeSecurity]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool CloseHandle(IntPtr handle);
            protected override bool ReleaseHandle()
            {
                return CloseHandle(handle);
            }
        }
    }
