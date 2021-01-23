    using System;
    using System.Security.Principal;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    /// <summary> 
    /// Leverages the Windows API (advapi32.dll) to programmatically impersonate a user. 
    /// </summary> 
    public class ImpersonationContext : IDisposable 
    { 
        #region constants 
     
        private const int LOGON32_LOGON_INTERACTIVE = 2; 
        private const int LOGON32_PROVIDER_DEFAULT = 0; 
     
        #endregion 
     
        #region global variables 
     
        private WindowsImpersonationContext impersonationContext; 
        private bool impersonating; 
     
        #endregion 
     
        #region unmanaged code 
     
        [DllImport("advapi32.dll")] 
        private static extern int LogonUserA(String lpszUserName, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken); 
     
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)] 
        private static extern int DuplicateToken(IntPtr hToken, int impersonationLevel, ref IntPtr hNewToken); 
     
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)] 
        private static extern bool RevertToSelf(); 
     
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)] 
        private static extern bool CloseHandle(IntPtr handle); 
     
        #endregion 
     
        #region constructors 
     
        public ImpersonationContext() 
        { 
            impersonating = false; 
        } 
     
        /// <summary> 
        /// Overloaded constructor and begins impersonating. 
        /// </summary> 
        public ImpersonationContext(string userName, string password, string domain) 
        { 
            this.BeginImpersonationContext(userName, password, domain); 
        } 
     
        #endregion 
     
        #region impersonation methods 
     
        /// <summary> 
        /// Begins the impersonation context for the specified user. 
        /// </summary> 
        /// <remarks>Don't call this method if you used the overloaded constructor.</remarks> 
        public void BeginImpersonationContext(string userName, string password, string domain) 
        { 
            //initialize token and duplicate variables 
            IntPtr token = IntPtr.Zero; 
            IntPtr tokenDuplicate = IntPtr.Zero; 
     
            if (RevertToSelf()) 
            { 
                if (LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref token) != 0) 
                { 
                    if (DuplicateToken(token, 2, ref tokenDuplicate) != 0) 
                    { 
                        using (WindowsIdentity tempWindowsIdentity = new WindowsIdentity(tokenDuplicate)) 
                        { 
                            //begin the impersonation context and mark impersonating true 
                            impersonationContext = tempWindowsIdentity.Impersonate(); 
                            impersonating = true; 
                        } 
                    } 
                } 
            } 
     
            //close the handle to the account token 
            if (token != IntPtr.Zero) 
                CloseHandle(token); 
     
            //close the handle to the duplicated account token 
            if (tokenDuplicate != IntPtr.Zero) 
                CloseHandle(tokenDuplicate); 
        } 
     
        /// <summary> 
        /// Ends the current impersonation context. 
        /// </summary> 
        public void EndImpersonationContext() 
        { 
            //if the context exists undo it and dispose of the object 
            if (impersonationContext != null) 
            { 
                //end the impersonation context and dispose of the object 
                impersonationContext.Undo(); 
                impersonationContext.Dispose(); 
            } 
     
            //mark the impersonation flag false 
            impersonating = false; 
        } 
     
        #endregion 
     
        #region properties 
     
        /// <summary> 
        /// Gets a value indicating whether the impersonation is currently active. 
        /// </summary> 
        public bool Impersonating 
        { 
            get 
            { 
                return impersonating; 
            } 
        } 
     
        #endregion 
     
        #region IDisposable implementation 
     
        ~ImpersonationContext() 
        { 
            Dispose(false); 
        } 
     
        public void Dispose() 
        { 
            Dispose(true);                
        } 
     
        protected virtual void Dispose(bool disposing) 
        { 
            if (disposing) 
            { 
                if (impersonationContext != null) 
                { 
                    impersonationContext.Undo(); 
                    impersonationContext.Dispose(); 
                } 
            } 
        } 
     
        #endregion     
    } 
