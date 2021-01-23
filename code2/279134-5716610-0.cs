      public class Impersonator : IDisposable
      {
    
        const int LOGON32_PROVIDER_DEFAULT = 0;
        const int LOGON32_LOGON_INTERACTIVE = 2;
    
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
    
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);
    
        private IntPtr token = IntPtr.Zero;
        private WindowsImpersonationContext impersonated;
        private readonly string _ErrMsg = "";
    
        public bool IsImpersonating
        {
          get { return (token != IntPtr.Zero) && (impersonated != null); }
        }
    
        public string ErrMsg
        {
          get { return _ErrMsg; }
        }
    
        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public Impersonator(string userName, string password, string domain)
        {
          StopImpersonating();
    
          bool loggedOn = LogonUser(userName, domain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref token);
          if (!loggedOn)
          {
            _ErrMsg = new System.ComponentModel.Win32Exception().Message;
            return;
          }
    
          WindowsIdentity identity = new WindowsIdentity(token);
          impersonated = identity.Impersonate();
        }
    
        private void StopImpersonating()
        {
          if (impersonated != null)
          {
            impersonated.Undo();
            impersonated = null;
          }
    
          if (token != IntPtr.Zero)
          {
            CloseHandle(token);
            token = IntPtr.Zero;
          }
        }
    
        public void Dispose()
        {
          StopImpersonating();
        }
      }
