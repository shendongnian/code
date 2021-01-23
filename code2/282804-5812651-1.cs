    public class Impersonator : IDisposable
    {
        private WindowsImpersonationContext _impersonatedUser = null;
        private IntPtr _userHandle;
    
        // constructor for a local account. username and password are arguments.
        public Impersonator(string username, string passwd)
        {
            _userHandle = new IntPtr(0);
    
            string user = username;
            string userDomain = "."; // The domain for a local user is by default "."
            string password = passwd;
    
            bool returnValue = LogonUser(user, userDomain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref _userHandle);
    
            if (!returnValue)
                throw new ApplicationException("Could not impersonate user");
    
            WindowsIdentity newId = new WindowsIdentity(_userHandle);
            _impersonatedUser = newId.Impersonate();
        }
    
        // constructor where username, password and domain are passed as parameters
        public Impersonator(string username, string passwd, string domain)
        {
            _userHandle = new IntPtr(0);
    
            string user = username;
            string userDomain = domain;
            string password = passwd;
    
            bool returnValue = LogonUser(user, userDomain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref _userHandle);
    
            if (!returnValue)
                throw new ApplicationException("Could not impersonate user");
    
            WindowsIdentity newId = new WindowsIdentity(_userHandle);
            _impersonatedUser = newId.Impersonate();
        }
    
        public void Dispose()
        {
            if (_impersonatedUser != null)
            {
                _impersonatedUser.Undo();
                CloseHandle(_userHandle);
            }
        }
    
        public const int LOGON32_LOGON_INTERACTIVE = 2;
        public const int LOGON32_LOGON_SERVICE = 3;
        public const int LOGON32_PROVIDER_DEFAULT = 0;
    
        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern bool LogonUser(String lpszUserName, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
    
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);
    }
