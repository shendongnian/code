    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApp2
    {
        class Program
        {
            private static IntPtr out_read;
            private static IntPtr out_write;
            private static IntPtr err_read;
            private static IntPtr err_write;
            private static int CREATE_NO_WINDOW = 0x08000000;
            private static int STARTF_USESTDHANDLES = 0x00000100;
            private static int BUFSIZE = 4096;
            private static int HANDLE_FLAG_INHERIT = 0x00000001;
            private static void Main(string[] args)
            {
                SECURITY_ATTRIBUTES saAttr = new SECURITY_ATTRIBUTES();
                saAttr.nLength = Marshal.SizeOf(typeof(SECURITY_ATTRIBUTES));
                saAttr.bInheritHandle = 0x1;
                saAttr.lpSecurityDescriptor = IntPtr.Zero;
    
                CreatePipe(ref out_read,ref out_write,ref saAttr, 0);
                CreatePipe(ref err_read, ref err_write,ref saAttr, 0);
    
                SetHandleInformation(out_read, HANDLE_FLAG_INHERIT, 0);
                SetHandleInformation(err_read, HANDLE_FLAG_INHERIT, 0);
                PROCESS_INFORMATION res;
                RunAsDesktopUser("C:\\test.exe",out res);
                byte[] buf = new byte[BUFSIZE];
                int dwRead = 0;
                while (true)
                {
                    bool bSuccess = ReadFile(out_read, buf, BUFSIZE, ref dwRead, IntPtr.Zero);
                    if (!bSuccess || dwRead == 0)
                        break;
                    Console.WriteLine(System.Text.Encoding.Default.GetString(buf));
                }
                CloseHandle(out_read);
                CloseHandle(err_read);
                CloseHandle(out_write);
                CloseHandle(err_write);
            }
            
            private static void RunAsDesktopUser(string fileName, out PROCESS_INFORMATION pi)
            {
                var si = new STARTUPINFO();
                pi = new PROCESS_INFORMATION();
                if (string.IsNullOrWhiteSpace(fileName))
                    throw new ArgumentException("Value cannot be null or whitespace.", nameof(fileName));
    
                // To start process as shell user you will need to carry out these steps:
                // 1. Enable the SeIncreaseQuotaPrivilege in your current token
                // 2. Get an HWND representing the desktop shell (GetShellWindow)
                // 3. Get the Process ID(PID) of the process associated with that window(GetWindowThreadProcessId)
                // 4. Open that process(OpenProcess)
                // 5. Get the access token from that process (OpenProcessToken)
                // 6. Make a primary token with that token(DuplicateTokenEx)
                // 7. Start the new process with that primary token(CreateProcessWithTokenW)
    
                var hProcessToken = IntPtr.Zero;
                // Enable SeIncreaseQuotaPrivilege in this process.  (This won't work if current process is not elevated.)
                try
                {
                    var process = GetCurrentProcess();
                    if (!OpenProcessToken(process, 0x0020, ref hProcessToken))
                        return;
    
                    var tkp = new TOKEN_PRIVILEGES
                    {
                        PrivilegeCount = 2,
                        Privileges = new LUID_AND_ATTRIBUTES[2]
                    };
    
                    if (!LookupPrivilegeValue(null, "SeIncreaseQuotaPrivilege", ref tkp.Privileges[0].Luid))
                        return;
                    if (!LookupPrivilegeValue(null, "SeImpersonatePrivilege", ref tkp.Privileges[1].Luid))
                        return;
    
                    tkp.Privileges[0].Attributes = 0x00000002;
                    tkp.Privileges[1].Attributes = 0x00000002;
    
                    if (!AdjustTokenPrivileges(hProcessToken, false, ref tkp, 0, IntPtr.Zero, IntPtr.Zero))
                        return;
                }
                finally
                {
                    CloseHandle(hProcessToken);
                }
    
                // Get an HWND representing the desktop shell.
                // CAVEATS:  This will fail if the shell is not running (crashed or terminated), or the default shell has been
                // replaced with a custom shell.  This also won't return what you probably want if Explorer has been terminated and
                // restarted elevated.
                var hwnd = GetShellWindow();
                if (hwnd == IntPtr.Zero)
                    return;
    
                var hShellProcess = IntPtr.Zero;
                var hShellProcessToken = IntPtr.Zero;
                var hPrimaryToken = IntPtr.Zero;
                try
                {
                    // Get the PID of the desktop shell process.
                    uint dwPID;
                    if (GetWindowThreadProcessId(hwnd, out dwPID) == 0)
                        return;
    
                    // Open the desktop shell process in order to query it (get the token)
                    hShellProcess = OpenProcess(ProcessAccessFlags.QueryInformation, false, dwPID);
                    if (hShellProcess == IntPtr.Zero)
                        return;
    
                    // Get the process token of the desktop shell.
                    if (!OpenProcessToken(hShellProcess, 0x0002, ref hShellProcessToken))
                        return;
    
                    var dwTokenRights = 395U;
    
                    // Duplicate the shell's process token to get a primary token.
                    // Based on experimentation, this is the minimal set of rights required for CreateProcessWithTokenW (contrary to current documentation).
                    if (!DuplicateTokenEx(hShellProcessToken, dwTokenRights, IntPtr.Zero, SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, TOKEN_TYPE.TokenPrimary, out hPrimaryToken))
                        return;
    
                    // Start the target process with the new token.
                    si.cb = Marshal.SizeOf(typeof(STARTUPINFO));
                    si.hStdOutput = out_write;
                    si.hStdError = err_write;
                    si.dwFlags |= STARTF_USESTDHANDLES;
                    if (!CreateProcessWithTokenW(hPrimaryToken, 0, fileName, "", CREATE_NO_WINDOW, IntPtr.Zero, Path.GetDirectoryName(fileName), ref si, out pi))
                        return;
                }
                finally
                {
                    CloseHandle(hShellProcessToken);
                    CloseHandle(hPrimaryToken);
                    CloseHandle(hShellProcess);
                }
                return;
            }
    
            #region Interop
    
    
            private struct TOKEN_PRIVILEGES
            {
                public UInt32 PrivilegeCount;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
                public LUID_AND_ATTRIBUTES[] Privileges;
            }
    
            [StructLayout(LayoutKind.Sequential, Pack = 4)]
            private struct LUID_AND_ATTRIBUTES
            {
                public LUID Luid;
                public UInt32 Attributes;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            private struct LUID
            {
                public uint LowPart;
                public int HighPart;
            }
    
            [Flags]
            private enum ProcessAccessFlags : uint
            {
                All = 0x001F0FFF,
                Terminate = 0x00000001,
                CreateThread = 0x00000002,
                VirtualMemoryOperation = 0x00000008,
                VirtualMemoryRead = 0x00000010,
                VirtualMemoryWrite = 0x00000020,
                DuplicateHandle = 0x00000040,
                CreateProcess = 0x000000080,
                SetQuota = 0x00000100,
                SetInformation = 0x00000200,
                QueryInformation = 0x00000400,
                QueryLimitedInformation = 0x00001000,
                Synchronize = 0x00100000
            }
    
            private enum SECURITY_IMPERSONATION_LEVEL
            {
                SecurityAnonymous,
                SecurityIdentification,
                SecurityImpersonation,
                SecurityDelegation
            }
    
            private enum TOKEN_TYPE
            {
                TokenPrimary = 1,
                TokenImpersonation
            }
    
            [StructLayout(LayoutKind.Sequential)]
            private struct PROCESS_INFORMATION
            {
                public IntPtr hProcess;
                public IntPtr hThread;
                public int dwProcessId;
                public int dwThreadId;
            }
            private struct SECURITY_ATTRIBUTES
            {
                public Int32 nLength;
                public IntPtr lpSecurityDescriptor;
                public int bInheritHandle;
            }
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            private struct STARTUPINFO
            {
                public Int32 cb;
                public string lpReserved;
                public string lpDesktop;
                public string lpTitle;
                public Int32 dwX;
                public Int32 dwY;
                public Int32 dwXSize;
                public Int32 dwYSize;
                public Int32 dwXCountChars;
                public Int32 dwYCountChars;
                public Int32 dwFillAttribute;
                public Int32 dwFlags;
                public Int16 wShowWindow;
                public Int16 cbReserved2;
                public IntPtr lpReserved2;
                public IntPtr hStdInput;
                public IntPtr hStdOutput;
                public IntPtr hStdError;
            }
    
            [DllImport("kernel32.dll", ExactSpelling = true)]
            private static extern IntPtr GetCurrentProcess();
    
            [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
            private static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);
    
            [DllImport("advapi32.dll", SetLastError = true)]
            private static extern bool LookupPrivilegeValue(string host, string name, ref LUID pluid);
    
            [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
            private static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall, ref TOKEN_PRIVILEGES newst, int len, IntPtr prev, IntPtr relen);
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool CloseHandle(IntPtr hObject);
    
    
            [DllImport("user32.dll")]
            private static extern IntPtr GetShellWindow();
    
            [DllImport("user32.dll", SetLastError = true)]
            private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, uint processId);
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr CreatePipe(ref IntPtr hReadPipe, ref IntPtr hWritePipe, ref SECURITY_ATTRIBUTES lpPipeAttributes,Int32 nSize);
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool ReadFile(IntPtr hFile, byte[] lpBuffer, int nNumberOfBytesToRead, ref int lpNumberOfBytesRead, IntPtr lpOverlapped/*IntPtr.Zero*/);
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool SetHandleInformation(IntPtr hObject, int dwMask, int dwFlags);
    
    
            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern bool DuplicateTokenEx(IntPtr hExistingToken, uint dwDesiredAccess, IntPtr lpTokenAttributes, SECURITY_IMPERSONATION_LEVEL impersonationLevel, TOKEN_TYPE tokenType, out IntPtr phNewToken);
    
            [DllImport("advapi32", SetLastError = true, CharSet = CharSet.Unicode)]
            private static extern bool CreateProcessWithTokenW(IntPtr hToken, int dwLogonFlags, string lpApplicationName, string lpCommandLine, int dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, [In] ref STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);
            #endregion
        }
    }
