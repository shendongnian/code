    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.ConstrainedExecution;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Permissions;
    using System.Security.Principal;
    using System.Text;
    using System.Windows;
    using Microsoft.Win32.SafeHandles;
    
    namespace ZZZ
    {
    
        partial class User : IDisposable
        {
            private string m_domain;
            private string m_user;
            private string m_pass;
    		private WindowsIdentity user;
    		private SafeTokenHandle safeTokenHandle;
    		private WindowsImpersonationContext impContext;
            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            private static extern bool LogonUser(
                string lpszUsername,
                string lpszDomain,
                string lpszPassword,
                int dwLogonType,
                int dwLogonProvider,
                out SafeTokenHandle phToken);
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            private extern static bool CloseHandle(IntPtr handle);
    
            [DllImport("advapi32.dll", SetLastError = true)]
            private static extern bool RevertToSelf();
    
            //For the current user
            public User()
            {
                user = WindowsIdentity.GetCurrent();
            }
    
            // For custom user
            public User(string domain, string user, string password, bool doImepsonate = false)
            {
                m_domain = domain;
                m_user = user;
                m_pass = password;
                if (doImepsonate) this.Impersonate();
            }
            // If it's intended to incorporate this code into a DLL, then demand FullTrust.
            [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
            public void Impersonate()
            {
                if (impContext != null) throw new ImpersonationException();
    
                try
                {
                    // Get the user token for the specified user, domain, and password using the unmanaged LogonUser method. 
                    // The local machine name can be used for the domain name to impersonate a user on this machine.
                    const int LOGON32_PROVIDER_DEFAULT = 0;
                    //This parameter causes LogonUser to create a primary token. 
                    const int LOGON32_LOGON_INTERACTIVE = 2;
    
                    // Call LogonUser to obtain a handle to an access token. 
                    bool returnValue = LogonUser(
                        m_user,
                        m_domain,
                        m_pass,
                        LOGON32_LOGON_INTERACTIVE,
                        LOGON32_PROVIDER_DEFAULT,
                        out safeTokenHandle);
    
                    if (returnValue == false)
                    {
                        int ret = Marshal.GetLastWin32Error();
                        throw new Win32Exception(ret);
                    }
    
                    using (safeTokenHandle)
                    {
                        // Use the token handle returned by LogonUser. 
                        user = new WindowsIdentity(safeTokenHandle.DangerousGetHandle());
                        impContext = user.Impersonate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception occurred:\n" + ex.Message);
                }
            }
    
            [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
            private void Quit()
            {
                if (impContext == null) return;
                impContext.Undo();
                safeTokenHandle.Dispose();
            }
            #endregion
    		internal IEnumerable<string> Groups
            {
                get
                {
                    return user.Groups.Select(p =>
                    {
                        IdentityReference ir = null;
                        try { ir = p.Translate(typeof(NTAccount)); }
                        catch { }
                        return ir == null ? null : ir.Value;
                    });
                }
            }
        }
    
        // Win32 API part
        internal sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            private SafeTokenHandle() : base(true) { }
    
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
    
        internal sealed class ImpersonationException : Exception
        {
            public ImpersonationException() : base("The user is already impersonated.") { }
        }
    
    }
