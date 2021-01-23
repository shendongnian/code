    public class ImpersonateUser : IDisposable
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out IntPtr phToken);
        [DllImport("kernel32", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);
        private IntPtr userHandle = IntPtr.Zero;
        private WindowsImpersonationContext impersonationContext;
        public ImpersonateUser(string user, string domain, string password)
        {
            if (!string.IsNullOrEmpty(user))
            {
                // Call LogonUser to get a token for the user
                bool loggedOn = LogonUser(user, domain, password,
                        9 /*(int)LogonType.LOGON32_LOGON_NEW_CREDENTIALS*/,
                        3 /*(int)LogonProvider.LOGON32_PROVIDER_WINNT50*/,
                        out userHandle);
                if (!loggedOn)
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                // Begin impersonating the user
                impersonationContext = WindowsIdentity.Impersonate(userHandle);
            }
        }
        public void Dispose()
        {
            if (userHandle != IntPtr.Zero)
                CloseHandle(userHandle);
            if (impersonationContext != null)
                impersonationContext.Undo();
        }
    }
