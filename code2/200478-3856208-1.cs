    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    using Microsoft.Win32;
    using System.IO;
    using System.Security.Principal;
    
    namespace Granite.WebWidgets.UtilityLib
    {
        public class Win32Process
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct STARTUPINFO
            {
                public int cb;
                public String lpReserved;
                public String lpDesktop;
                public String lpTitle;
                public uint dwX;
                public uint dwY;
                public uint dwXSize;
                public uint dwYSize;
                public uint dwXCountChars;
                public uint dwYCountChars;
                public uint dwFillAttribute;
                public uint dwFlags;
                public short wShowWindow;
                public short cbReserved2;
                public IntPtr lpReserved2;
                public IntPtr hStdInput;
                public IntPtr hStdOutput;
                public IntPtr hStdError;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            public struct PROCESS_INFORMATION
            {
                public IntPtr hProcess;
                public IntPtr hThread;
                public uint dwProcessId;
                public uint dwThreadId;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            public struct SECURITY_ATTRIBUTES
            {
                public int Length;
                public IntPtr lpSecurityDescriptor;
                public bool bInheritHandle;
            }
    
            [DllImport("kernel32.dll", EntryPoint = "CloseHandle", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public extern static bool CloseHandle(IntPtr handle);
    
            [DllImport("advapi32.dll", EntryPoint = "CreateProcessAsUser", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
            public extern static bool CreateProcessAsUser(IntPtr hToken, String lpApplicationName, String lpCommandLine, ref SECURITY_ATTRIBUTES lpProcessAttributes,
                ref SECURITY_ATTRIBUTES lpThreadAttributes, bool bInheritHandle, int dwCreationFlags, IntPtr lpEnvironment,
                String lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);
    
            [DllImport("advapi32.dll", EntryPoint = "DuplicateTokenEx")]
            public extern static bool DuplicateTokenEx(IntPtr ExistingTokenHandle, uint dwDesiredAccess,
                ref SECURITY_ATTRIBUTES lpThreadAttributes, int TokenType,
                int ImpersonationLevel, ref IntPtr DuplicateTokenHandle);
    
    
            public static void CreateProcess(string cmdline)
            {
                IntPtr Token = new IntPtr(0);
    			IntPtr DupedToken = new IntPtr(0);
    			bool      ret;
    			//Label2.Text+=WindowsIdentity.GetCurrent().Name.ToString();
    			
    
    			SECURITY_ATTRIBUTES sa  = new SECURITY_ATTRIBUTES();
    			sa.bInheritHandle       = false;
    			sa.Length               = Marshal.SizeOf(sa);
    			sa.lpSecurityDescriptor = (IntPtr)0;
    			
    			Token = WindowsIdentity.GetCurrent().Token;
    
    			const uint GENERIC_ALL = 0x10000000;
    
    			const int SecurityImpersonation = 2;
    			const int TokenType = 1;
    
    			ret = DuplicateTokenEx(Token, GENERIC_ALL, ref sa, SecurityImpersonation, TokenType, ref DupedToken);
    
                if (ret == false)
                {
                    throw new Exception("DuplicateTokenEx failed with " + Marshal.GetLastWin32Error());
                }
    
    
    			STARTUPINFO si          = new STARTUPINFO();
    			si.cb                   = Marshal.SizeOf(si);
    			si.lpDesktop            = "";
    
                string commandLinePath = cmdline;
    
    			PROCESS_INFORMATION pi  = new PROCESS_INFORMATION();
    			ret = CreateProcessAsUser(DupedToken,null,commandLinePath, ref sa, ref sa, false, 0, (IntPtr)0, "c:\\", ref si, out pi);
    
                if (ret == false)
                {
                    throw new Exception("CreateProcessAsUser failed with " + Marshal.GetLastWin32Error() + ": if 1314, make sure user is a member 'Replace a process level token' Control Panel -> Administrative Tools -> Local Security Settings.");
                }
                else
                {
                    CloseHandle(pi.hProcess);
                    CloseHandle(pi.hThread);
                }
    
    			ret = CloseHandle(DupedToken);
                if (ret == false)
                {
                    throw new Exception(Marshal.GetLastWin32Error().ToString());
                }
    
            }
    
        }
    }
