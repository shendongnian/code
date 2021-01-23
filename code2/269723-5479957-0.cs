    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using System.Security.Principal;
    using System.Reflection;
    
    namespace WindowsFormsApplication2
    {
        
        public class ProcessHelper
        {
            [DllImport("advapi32.dll", SetLastError = true)]
            private static extern bool OpenProcessToken(IntPtr ProcessHandle, UInt32 DesiredAccess, out IntPtr TokenHandle);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool CloseHandle(IntPtr hObject);
    
            private const int TOKEN_QUERY = 0x8;
    
            public static bool IsProcessOwnerAdmin(string processName)
            {
                Process proc = Process.GetProcessesByName(processName)[0];
    
                IntPtr ph = IntPtr.Zero;
    
                OpenProcessToken(proc.Handle, TOKEN_QUERY, out ph);
    
                WindowsIdentity iden = new WindowsIdentity(ph);
    
                bool result = false;
    
                foreach (IdentityReference role in iden.Groups)
                {
                    if (role.IsValidTargetType(typeof(SecurityIdentifier)))
                    {
                        SecurityIdentifier sid = role as SecurityIdentifier;
    
                        if (sid.IsWellKnown(WellKnownSidType.AccountAdministratorSid) || sid.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid))
                        {
                            result = true;
                            break;
                        }
                    }
                }
    
                CloseHandle(ph);
    
                return result;
            }
        }
    
        static class Program
        {
            [STAThread]
            static void Main()
            {
                bool isAdmin = ProcessHelper.IsProcessOwnerAdmin("outlook");
            }
        }
    }
