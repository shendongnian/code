    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Security.AccessControl;
    namespace PermissionsExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                string source = "C:\\source.txt";
                string dest = "C:\\dest.txt";
                string result = CopyPermissions(source, dest);
                if (!string.IsNullOrEmpty(result)) { Console.WriteLine(result); }
                else { Console.WriteLine("SUCCESS"); }
            }
            public static string CopyPermissions(string source_file, string dest_file)
            {
                string errmsg = string.Empty;
                IntPtr sidOwner = IntPtr.Zero;
                IntPtr sidOwnerDescriptor = IntPtr.Zero;
                IntPtr sidGroup = IntPtr.Zero;
                IntPtr sidGroupDescriptor = IntPtr.Zero;
                IntPtr dacl = IntPtr.Zero;
                IntPtr daclDescriptor = IntPtr.Zero;
                IntPtr sacl = IntPtr.Zero;
                try
                {
                    int result = GetNamedSecurityInfo(source_file, SE_OBJECT_TYPE.SE_FILE_OBJECT, SecurityInfos.DiscretionaryAcl, out sidOwner, out sidGroup, out dacl, out sacl, out daclDescriptor);
                    if (result != 0)
                    {
                        Win32Exception e = new Win32Exception(result);
                        errmsg = "ERROR: " + e.Message;
                        return errmsg;
                    }
                    result = GetNamedSecurityInfo(source_file, SE_OBJECT_TYPE.SE_FILE_OBJECT, SecurityInfos.Owner, out sidOwner, out sidGroup, out dacl, out sacl, out sidGroupDescriptor);
                    if (result != 0)
                    {
                        Win32Exception e = new Win32Exception(result);
                        errmsg = "ERROR: " + e.Message;
                        return errmsg;
                    }
                    result = GetNamedSecurityInfo(source_file, SE_OBJECT_TYPE.SE_FILE_OBJECT, SecurityInfos.Group, out sidOwner, out sidGroup, out dacl, out sacl, out sidGroupDescriptor);
                    if (result != 0)
                    {
                        Win32Exception e = new Win32Exception(result);
                        errmsg = "ERROR: " + e.Message;
                        return errmsg;
                    }
                    SecurityInfos info = SecurityInfos.DiscretionaryAcl | SecurityInfos.Group | SecurityInfos.Owner;
                    result = SetNamedSecurityInfo(dest_file, SE_OBJECT_TYPE.SE_FILE_OBJECT, info, sidOwner, sidGroup, dacl, sacl);
                    if (result != 0)
                    {
                        Win32Exception e = new Win32Exception(result);
                        errmsg = "ERROR: " + e.Message;
                        return errmsg;
                    }
                }
                finally
                {
                    if (sidOwnerDescriptor != IntPtr.Zero && LocalFree(sidOwnerDescriptor) != IntPtr.Zero)
                    {
                        int err = Marshal.GetLastWin32Error();
                        Win32Exception e = new Win32Exception(err);
                        errmsg += "ERROR: " + e.Message;
                    }
                    if (sidGroupDescriptor != IntPtr.Zero && LocalFree(sidGroupDescriptor) != IntPtr.Zero)
                    {
                        int err = Marshal.GetLastWin32Error();
                        Win32Exception e = new Win32Exception(err);
                        errmsg += "ERROR: " + e.Message;
                    }
                    if (daclDescriptor != IntPtr.Zero && LocalFree(daclDescriptor) != IntPtr.Zero)
                    {
                        int err = Marshal.GetLastWin32Error();
                        Win32Exception e = new Win32Exception(err);
                        errmsg += "ERROR: " + e.Message;
                    }
                }
                return errmsg;
            }
            public enum SE_OBJECT_TYPE
            {
                SE_UNKNOWN_OBJECT_TYPE = 0,
                SE_FILE_OBJECT,
                SE_SERVICE,
                SE_PRINTER,
                SE_REGISTRY_KEY,
                SE_LMSHARE,
                SE_KERNEL_OBJECT,
                SE_WINDOW_OBJECT,
                SE_DS_OBJECT,
                SE_DS_OBJECT_ALL,
                SE_PROVIDER_DEFINED_OBJECT,
                SE_WMIGUID_OBJECT,
                SE_REGISTRY_WOW64_32KEY
            }
            [DllImport("advapi32.dll", EntryPoint = "GetNamedSecurityInfoW", ExactSpelling = true, CharSet = CharSet.Unicode)]
            private static extern int GetNamedSecurityInfo(string objectName, SE_OBJECT_TYPE objectType,
                System.Security.AccessControl.SecurityInfos securityInfo, out IntPtr sidOwner,
                out IntPtr sidGroup, out IntPtr dacl, out IntPtr sacl, out IntPtr securityDescriptor);
            [DllImport("advapi32.dll", EntryPoint = "SetNamedSecurityInfoW", ExactSpelling = true, CharSet = CharSet.Unicode)]
            private static extern int SetNamedSecurityInfo(string objectName, SE_OBJECT_TYPE objectType,
                System.Security.AccessControl.SecurityInfos securityInfo, IntPtr sidOwner,
                IntPtr sidGroup, IntPtr dacl, IntPtr sacl);
            [DllImport("kernel32.dll", EntryPoint = "LocalFree", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Unicode)]
            private static extern IntPtr LocalFree(IntPtr hMem);
        }
    }
