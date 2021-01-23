    public class WinApiDomainAuthenticator
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(string lpszUsername,
                                            string lpszDomain,
                                            string lpszPassword,
                                            int dwLogonType,
                                            int dwLogonProvider,
                                            out IntPtr phToken);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);
        public static IPrincipal Authenticate(String domainUser, String password)
        {
            var userToken = IntPtr.Zero;
            var creds = new DomainAuthCredentials(domainUser, password); 
            if (! LogonUser(creds.Username, 
                            creds.Domain,
                            creds.Password,
                           (int)LogonType.LOGON32_LOGON_BATCH, 
                           (int)LogonProvider.LOGON32_PROVIDER_DEFAULT, out userToken))
            {
                var error = new Win32Exception(Marshal.GetLastWin32Error());
                throw new SecurityException("Error while authenticating user", error);
            }
            var identity = new WindowsIdentity(userToken);
            if (userToken != IntPtr.Zero) 
                CloseHandle(userToken);
            return ConvertWindowsIdentityToGenericPrincipal(identity);
        }
        protected static IPrincipal ConvertWindowsIdentityToGenericPrincipal(WindowsIdentity windowsIdentity)
        {
            if (windowsIdentity == null)
                return null;
            // Identity in format DOMAIN\Username
            var identity = new GenericIdentity(windowsIdentity.Name);
            var groupNames = new string[0];
            if (windowsIdentity.Groups != null)
            {
                // Array of Group-Names in format DOMAIN\Group
                groupNames = windowsIdentity.Groups
                                            .Select(gId => gId.Translate(typeof(NTAccount)))
                                            .Select(gNt => gNt.ToString())
                                            .ToArray();
            }
           
            var genericPrincipal = new GenericPrincipal(identity, groupNames);
            return genericPrincipal;
        }
        protected class DomainAuthCredentials
        {
            public DomainAuthCredentials(String domainUser, String password)
            {
                Username = domainUser;
                Password = password;
                Domain = ".";
                
                if (!domainUser.Contains(@"\"))
                    return;
                var tokens = domainUser.Split(new char[] { '\\' }, 2);
                Domain = tokens[0];
                Username = tokens[1];
            }
            public DomainAuthCredentials()
            {
                Domain = String.Empty;
            }
            #region Properties
            public String Domain { get; set; }
            public String Username { get; set; }
            public String Password { get; set; }
            #endregion
        }
    }
