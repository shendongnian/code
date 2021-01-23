    using System;
    using System.Runtime.InteropServices;
    using System.Security.Principal;
    using System.Configuration;
    namespace App_Code
    {
        public class Impersonation : IDisposable
        {
            private WindowsImpersonationContext _impersonationContext;
            #region Win32 API Declarations
            private const int Logon32LogonInteractive = 2; //This parameter causes LogonUser to create a primary token.
            private const int Logon32ProviderDefault = 0;
            [DllImport("advapi32.dll")]
            private static extern int LogonUserA(String lpszUserName, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern int DuplicateToken(IntPtr hToken, int impersonationLevel, ref IntPtr hNewToken);
            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern bool RevertToSelf();
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            private static extern bool CloseHandle(IntPtr handle);
            #endregion
            public bool ImpersonateDefaultFtpUser()
            {
                return ImpersonateFtpUser(ConfigurationManager.AppSettings["ftpUsername"], ConfigurationManager.AppSettings["ftpDomain"], ConfigurationManager.AppSettings["ftpPassword"]);
            }
            public bool ImpersonateFtpUser(string userName, string domain, string password)
            {
                WindowsIdentity tempWindowsIdentity;
                var token = IntPtr.Zero;
                var tokenDuplicate = IntPtr.Zero;
                if (RevertToSelf())
                {
                    if (LogonUserA(userName, domain, password, Logon32LogonInteractive, Logon32ProviderDefault, ref token) != 0)
                    {
                        if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                        {
                            tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
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
                if (_impersonationContext != null)
                    _impersonationContext.Undo();
            }
            /// <summary>
            /// Constructor. Impersonates the default ftp user. Impersonation lasts until
            /// the instance is disposed.
            /// </summary>
            public Impersonation()
            {
                ImpersonateDefaultFtpUser();
            }
            /// <summary>
            /// Constructor. Impersonates the requested user. Impersonation lasts until
            /// the instance is disposed.
            /// </summary>
            public Impersonation(string userName, string domain, string password)
            {
                ImpersonateFtpUser(userName, domain, password);
            }
            #region IDisposable Pattern
            /// <summary>
            /// Revert to original user and cleanup.
            /// </summary>
            protected virtual void Dispose(bool disposing)
            {
                if (!disposing) return;
                // Revert to original user identity
                UndoImpersonation();
                if (_impersonationContext != null)
                    _impersonationContext.Dispose();
            }
            /// <summary>
            /// Explicit dispose.
            /// </summary>
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            /// <summary>
            /// Destructor
            /// </summary>
            ~Impersonation()
            {
                Dispose(false);
            }
            #endregion
        }
    }
