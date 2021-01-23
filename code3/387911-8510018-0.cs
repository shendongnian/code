    public class Impersonation : IDisposable
    {
        private WindowsImpersonationContext _impersonatedUserContext;
        // Declare signatures for Win32 LogonUser and CloseHandle APIs
        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool LogonUser(
          string principal,
          string authority,
          string password,
          LogonSessionType logonType,
          LogonProvider logonProvider,
          out IntPtr token);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr handle);
        
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int DuplicateToken(IntPtr hToken,
            int impersonationLevel,
            ref IntPtr hNewToken);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool RevertToSelf();
        // ReSharper disable UnusedMember.Local
        enum LogonSessionType : uint
        {
            Interactive = 2,
            Network,
            Batch,
            Service,
            NetworkCleartext = 8,
            NewCredentials
        }
        // ReSharper disable InconsistentNaming
        enum LogonProvider : uint
        {
            Default = 0, // default for platform (use this!)
            WinNT35,     // sends smoke signals to authority
            WinNT40,     // uses NTLM
            WinNT50      // negotiates Kerb or NTLM
        }
        // ReSharper restore InconsistentNaming
        // ReSharper restore UnusedMember.Local
        /// <summary>
        /// Class to allow running a segment of code under a given user login context
        /// </summary>
        /// <param name="user">domain\user</param>
        /// <param name="password">user's domain password</param>
        public Impersonation(string user, string password)
        {
            var token = ValidateParametersAndGetFirstLoginToken(user, password);
            var duplicateToken = IntPtr.Zero;
            try
            {
                if (DuplicateToken(token, 2, ref duplicateToken) == 0)
                {
                    throw new Exception("DuplicateToken call to reset permissions for this token failed");
                }
                var identityForLoggedOnUser = new WindowsIdentity(duplicateToken);
                _impersonatedUserContext = identityForLoggedOnUser.Impersonate();
                if (_impersonatedUserContext == null)
                {
                    throw new Exception("WindowsIdentity.Impersonate() failed");
                }
            }
            finally
            {
                if (token != IntPtr.Zero)
                    CloseHandle(token);
                if (duplicateToken != IntPtr.Zero)
                    CloseHandle(duplicateToken);
            }
        }
        private static IntPtr ValidateParametersAndGetFirstLoginToken(string user, string password)
        {
            if (string.IsNullOrEmpty(user))
            {
                throw new ConfigurationErrorsException("No user passed into impersonation class");
            }
            var userHaves = user.Split('\\');
            if (userHaves.Length != 2)
            {
                throw new ConfigurationErrorsException("User must be formatted as follows: domain\\user");
            }
            if (!RevertToSelf())
            {
                throw new Exception("RevertToSelf call to remove any prior impersonations failed");
            }
            IntPtr token;
            var result = LogonUser(userHaves[1], userHaves[0],
                                   password,
                                   LogonSessionType.Interactive,
                                   LogonProvider.Default,
                                   out token);
            if (!result)
            {
                throw new ConfigurationErrorsException("Logon for user " + user + " failed.");
            }
            return token;
        }
        public void Dispose()
        {
            // Stop impersonation and revert to the process identity
            if (_impersonatedUserContext != null)
            {
                _impersonatedUserContext.Undo();
                _impersonatedUserContext = null;
            }
        }
    }
