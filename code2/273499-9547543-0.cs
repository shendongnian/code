    using System;
    using System.Runtime.ConstrainedExecution;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Permissions;
    using System.Security.Principal;
    using System.Web.Mvc;
    using Microsoft.Win32;
    using Microsoft.Win32.SafeHandles;
    
    namespace StackOimpersonationExample.Controllers
    {
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public class HomeController : Controller
        {
            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
                                                int dwLogonType, int dwLogonProvider, out TokenHandle phToken);
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern bool CloseHandle(IntPtr handle);
    
            public ActionResult Index()
            {
                ViewBag.Message = "This line contains status info.";
    
    
                #region ImpersonateTestUserAndWriteToRegistry
    
                try
                {
                    const string domainName = "W8CP";
                    const string userName = "testadmin";
                    const string password = "sxt";
    
                    TokenHandle tokenHandle;
                    bool returnValue = LogonUser(userName, domainName, password, 2, 0, out tokenHandle);
    
                    if (returnValue == false)
                    {
                        int retVal = Marshal.GetLastWin32Error();
                        ViewBag.Message = String.Format("Failed logon: {0}", retVal);
                        throw new System.ComponentModel.Win32Exception(retVal);
                    }
                    using (tokenHandle)
                    {
                        ViewBag.Message = "Logon successful!";
                        var newId = new WindowsIdentity(tokenHandle.DangerousGetHandle());
                        using (newId.Impersonate())
                        {
                            RegistryKey parentKey = Registry.LocalMachine;
                            RegistryKey softwareKey = parentKey.OpenSubKey("SOFTWARE", true);
                            if (softwareKey != null)
                            {
                                RegistryKey subKey = softwareKey.CreateSubKey("StackAnswer");
    
                                subKey.SetValue("CreatedAs", WindowsIdentity.GetCurrent().Name, RegistryValueKind.String);
                                subKey.SetValue("Website", "http://codecentral.org", RegistryValueKind.String);
                                subKey.SetValue("Email", "tonci.jukic@gmail.com", RegistryValueKind.String);
    
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message += String.Format(" Exception: " + ex.Message);
                }
                #endregion
    
                return View();
            }
        }
    
        public sealed class TokenHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            private TokenHandle(): base(true){}
    
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
    }
