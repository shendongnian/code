    /// <summary>
    /// Provides a mechanism for impersonating a user.  This is intended to be disposable, and
    /// used in a using ( ) block.
    /// </summary>
    public class Impersonation : IDisposable
    {
        #region Externals
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool LogonUser(
            string lpszUsername,
            string lpszDomain,
            string lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            out IntPtr phToken);
        [DllImport("advapi32.dll", SetLastError = true)]
        private extern static bool DuplicateToken(IntPtr ExistingTokenHandle, int
           SECURITY_IMPERSONATION_LEVEL, out IntPtr DuplicateTokenHandle);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);
        #endregion
        #region Fields
        private IntPtr token;
        private IntPtr tokenDuplicate;
        private WindowsIdentity identity;
        private WindowsImpersonationContext context;
        private readonly string domain;
        private readonly string username;
        private readonly string password;
        private ImpersonationLevel level;
        #endregion
        #region Constructor
        /// <summary>
        /// Initialises a new instance of <see cref="Impersonation"/>.
        /// </summary>
        /// <param name="domain">The domain of the target user.</param>
        /// <param name="username">The target user to impersonate.</param>
        /// <param name="password">The target password of the user to impersonate.</param>
        public Impersonation(string domain, string username, string password)
        {
            this.domain = domain;
            this.username = username;
            this.password = password;
            this.level = ImpersonationLevel.Impersonation;
            Logon();
        }
        /// <summary>
        /// Initialises a new instance of <see cref="Impersonation"/>.
        /// </summary>
        /// <param name="domain">The domain of the target user.</param>
        /// <param name="username">The target user to impersonate.</param>
        /// <param name="password">The target password of the user to impersonate.</param>
        /// <param name="level">The security level of this impersonation.</param>
        public Impersonation(string domain, string username, string password, ImpersonationLevel level)
        {
            this.domain = domain;
            this.username = username;
            this.password = password;
            this.level = level;
            Logon();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Reverts the impersonation.
        /// </summary>
        public void Dispose()
        {
            if (context != null)
                context.Undo();
            if (token != IntPtr.Zero)
                CloseHandle(token);
            if (tokenDuplicate != IntPtr.Zero)
                CloseHandle(tokenDuplicate);
        }
        /// <summary>
        /// Performs the logon.
        /// </summary>
        private void Logon()
        {
            if (LogonUser(username, domain, password, 2, 0, out token))
            {
                if (DuplicateToken(token, (int)level, out tokenDuplicate))
                {
                    identity = new WindowsIdentity(tokenDuplicate);
                    context = identity.Impersonate();
                }
                else
                {
                    throw new SecurityException("Unable to impersonate the user.");
                }
            }
            else
            {
                throw new SecurityException("The login details you have entered were incorrect.");
            }
        }
        #endregion
    }
    /// <summary>
    /// Defines the possible security levels for impersonation.
    /// </summary>
    public enum ImpersonationLevel
    {
        /// <summary>
        /// Anonymous access, the process is unable to identify the security context.
        /// </summary>
        Anonymous = 0,
        /// <summary>
        /// The process can identify the security context.
        /// </summary>
        Identification = 1,
        /// <summary>
        /// The security context can be used to access local resources.
        /// </summary>
        Impersonation = 2,
        /// <summary>
        /// The security context can be used to access remote resources.
        /// </summary>
        Delegation = 3
    }
