    /// <summary>
    /// Summary description for Impersonate
    /// </summary>
    public class Impersonate
    {
        #region "Class Members"
        public const int LOGON32_LOGON_INTERACTIVE = 2;
        public const int LOGON32_PROVIDER_DEFAULT = 0;
        WindowsImpersonationContext _impersonationContext;
        #endregion
        #region "Class Properties"
        private string domainName { get; set; }
        private string userName { get; set; }
        private string userPassword { get; set; }
        #endregion
        public Impersonate(string domainName, string userName, string userPassword)
        {
            this.domainName = domainName;
            this.userName = userName;
            this.userPassword = userPassword;
        }
        #region "Impersonation Code"
        [DllImport("advapi32.dll")]
        public static extern int LogonUserA(String lpszUserName,
            String lpszDomain,
            String lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            ref IntPtr phToken);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int DuplicateToken(IntPtr hToken,
            int impersonationLevel,
            ref IntPtr hNewToken);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool RevertToSelf();
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public bool ImpersonateValidUser()
        {
            var token = IntPtr.Zero;
            var tokenDuplicate = IntPtr.Zero;
            if (RevertToSelf())
            {
                if (LogonUserA(this.userName, this.domainName, this.userPassword, LOGON32_LOGON_INTERACTIVE,
                    LOGON32_PROVIDER_DEFAULT, ref token) != 0)
                {
                    if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                    {
                        var tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                        _impersonationContext = tempWindowsIdentity.Impersonate();
                        
                        if (_impersonationContext != null)
                        {
                            CloseHandle(token);
                            CloseHandle(tokenDuplicate);
                            return true;
                        }
                    }
                }
            }
            if (token != IntPtr.Zero)
                CloseHandle(token);
            if (tokenDuplicate != IntPtr.Zero)
                CloseHandle(tokenDuplicate);
            return false;
        }
        public void UndoImpersonation()
        {
            _impersonationContext.Undo();
        }
        #endregion
    }
