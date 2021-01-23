    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.ComponentModel;
    
    namespace HiddenDesktop {
        class Program {
            static void Main (string[] args) {
                string desktopName = "MyDesktop";
                string appPath = @"%SystemRoot%\system32\cmd.exe";
                string parameters = @"/c dir C:\ >%TEMP%\dir.txt";
                IntPtr hDesktop = IntPtr.Zero;
                NativeMethods.ProcessInformation processInfo = new NativeMethods.ProcessInformation ();
                bool isSuccess;
    
                try {
                    hDesktop = NativeMethods.CreateDesktop (desktopName, null, null, 0,
                            NativeMethods.ACCESS_MASK.MAXIMUM_ALLOWED, null);
                    if (hDesktop == IntPtr.Zero) {
                        DisplayLastErrorMessage ();
                        return;
                    }
    
                    NativeMethods.StartupInfo startupInfo = new NativeMethods.StartupInfo ();
                    NativeMethods.CreateProcessFlags dwCreationFlags = NativeMethods.CreateProcessFlags.NormalPriorityClass;
                    startupInfo.cb = Marshal.SizeOf (typeof (NativeMethods.StartupInfo));
                    startupInfo.lpDesktop = "WinSta0\\" + desktopName;
                    string currentDirectory = Environment.CurrentDirectory;
                    appPath = Environment.ExpandEnvironmentVariables (appPath);
                    //if (appPath.IndexOf (' ') != -1)
                    //    appPath = '\"' + appPath + '\"';
                    StringBuilder sbParameters = new StringBuilder (3 + appPath.Length + parameters.Length);
                    if (appPath.IndexOf (' ') != -1) {
                        sbParameters.Append ('\"');
                        sbParameters.Append (appPath);
                        sbParameters.Append ('\"');
                    }
                    else
                        sbParameters.Append (appPath);
                    sbParameters.Append (' ');
                    sbParameters.Append (parameters);
                    // appPath - full path to the exe without having " if the file has blanks in the path
                    isSuccess = NativeMethods.CreateProcess (appPath,
                        sbParameters.ToString(), IntPtr.Zero, IntPtr.Zero, false, dwCreationFlags,
                    IntPtr.Zero, currentDirectory, ref startupInfo, out processInfo);
                    if (!isSuccess) {
                        DisplayLastErrorMessage ();
                        return;
                    }
                    NativeMethods.CloseHandle (processInfo.hThread);
                    processInfo.hThread = IntPtr.Zero;
    
                    if (NativeMethods.WaitForSingleObject (processInfo.hProcess, NativeMethods.Infinite) == NativeMethods.WaitObject0) {
                        Console.WriteLine ("the process is ended");
                    }
                }
                finally {
                    if (processInfo.hThread != IntPtr.Zero)
                        isSuccess = NativeMethods.CloseHandle (processInfo.hThread);
                    if (processInfo.hProcess != IntPtr.Zero)
                        isSuccess = NativeMethods.CloseHandle (processInfo.hProcess);
                    if (hDesktop != IntPtr.Zero)
                        isSuccess = NativeMethods.CloseDesktop (hDesktop);
                }
            }
            static void DisplayLastErrorMessage () {
                int errorCode = Marshal.GetLastWin32Error ();
                Win32Exception error32 = new Win32Exception (errorCode);
                Console.WriteLine ("Error {0}: {1}", errorCode, error32.Message);
            }
        }
        internal static class NativeMethods {
            internal const int NoError = 0;
            internal const UInt32 Infinite = 0xFFFFFFFF;
    
            internal const UInt32 WaitAbandoned = 0x00000080;
            internal const UInt32 WaitObject0 = 0x00000000;
            internal const UInt32 WaitTimeout = 0x00000102;
    
            [Flags]
            internal enum ACCESS_MASK : uint {
                DELETE = 0x00010000,
                READ_CONTROL = 0x00020000,
                WRITE_DAC = 0x00040000,
                WRITE_OWNER = 0x00080000,
                SYNCHRONIZE = 0x00100000,
    
                STANDARD_RIGHTS_REQUIRED = 0x000f0000,
    
                STANDARD_RIGHTS_READ = 0x00020000,
                STANDARD_RIGHTS_WRITE = 0x00020000,
                STANDARD_RIGHTS_EXECUTE = 0x00020000,
    
                STANDARD_RIGHTS_ALL = 0x001f0000,
    
                SPECIFIC_RIGHTS_ALL = 0x0000ffff,
    
                ACCESS_SYSTEM_SECURITY = 0x01000000,
    
                MAXIMUM_ALLOWED = 0x02000000,
    
                GENERIC_READ = 0x80000000,
                GENERIC_WRITE = 0x40000000,
                GENERIC_EXECUTE = 0x20000000,
                GENERIC_ALL = 0x10000000,
    
                DESKTOP_READOBJECTS = 0x00000001,
                DESKTOP_CREATEWINDOW = 0x00000002,
                DESKTOP_CREATEMENU = 0x00000004,
                DESKTOP_HOOKCONTROL = 0x00000008,
                DESKTOP_JOURNALRECORD = 0x00000010,
                DESKTOP_JOURNALPLAYBACK = 0x00000020,
                DESKTOP_ENUMERATE = 0x00000040,
                DESKTOP_WRITEOBJECTS = 0x00000080,
                DESKTOP_SWITCHDESKTOP = 0x00000100,
    
                WINSTA_ENUMDESKTOPS = 0x00000001,
                WINSTA_READATTRIBUTES = 0x00000002,
                WINSTA_ACCESSCLIPBOARD = 0x00000004,
                WINSTA_CREATEDESKTOP = 0x00000008,
                WINSTA_WRITEATTRIBUTES = 0x00000010,
                WINSTA_ACCESSGLOBALATOMS = 0x00000020,
                WINSTA_EXITWINDOWS = 0x00000040,
                WINSTA_ENUMERATE = 0x00000100,
                WINSTA_READSCREEN = 0x00000200,
    
                WINSTA_ALL_ACCESS = 0x0000037f
            }
    
            [StructLayout (LayoutKind.Sequential)]
            public class SECURITY_ATTRIBUTES {
                public int nLength;
                public IntPtr lpSecurityDescriptor;
                public int bInheritHandle;
            }
            [StructLayout (LayoutKind.Sequential)]
            internal struct ProcessInformation {
                internal IntPtr hProcess;
                internal IntPtr hThread;
                internal int dwProcessId;
                internal int dwThreadId;
            }
    
            [StructLayout (LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            internal struct StartupInfo {
                internal Int32 cb;
                internal string lpReserved;
                internal string lpDesktop;
                internal string lpTitle;
                internal Int32 dwX;
                internal Int32 dwY;
                internal Int32 dwXSize;
                internal Int32 dwYSize;
                internal Int32 dwXCountChars;
                internal Int32 dwYCountChars;
                internal Int32 dwFillAttribute;
                internal Int32 dwFlags;
                internal Int16 wShowWindow;
                internal Int16 cbReserved2;
                internal IntPtr lpReserved2;
                internal IntPtr hStdInput;
                internal IntPtr hStdOutput;
                internal IntPtr hStdError;
            }
            [Flags]
            internal enum CreateProcessFlags : uint {
                DebugProcess = 0x00000001,
                DebugOnlyThisProcess = 0x00000002,
                CreateSuspended = 0x00000004,
                DetachedProcess = 0x00000008,
                CreateNewConsole = 0x00000010,
                NormalPriorityClass = 0x00000020,
                IdlePriorityClass = 0x00000040,
                HighPriorityClass = 0x00000080,
                RealtimePriorityClass = 0x00000100,
                CreateNewProcessGroup = 0x00000200,
                CreateUnicodeEnvironment = 0x00000400,
                CreateSeparateWowVdm = 0x00000800,
                CreateSharedWowVdm = 0x00001000,
                CreateForcedos = 0x00002000,
                BelowNormalPriorityClass = 0x00004000,
                AboveNormalPriorityClass = 0x00008000,
                InheritParentAffinity = 0x00010000,
                InheritCallerPriority = 0x00020000,  // Deprecated
                CreateProtectedProcess = 0x00040000,
                ExtendedStartupinfoPresent = 0x00080000,
                ProcessModeBackgroundBegin = 0x00100000,
                ProcessModeBackgroundEnd = 0x00200000,
                CreateBreakawayFromJob = 0x01000000,
                CreatePreserveCodeAuthzLevel = 0x02000000,
                CreateDefaultErrorMode = 0x04000000,
                CreateNoWindow = 0x08000000,
                ProfileUser = 0x10000000,
                ProfileKernel = 0x20000000,
                ProfileServer = 0x40000000,
                CreateIgnoreSystemDefault = 0x80000000,
            }
    
            [DllImport ("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern IntPtr CreateDesktop (
                            string desktopName,
                            string device, // must be null.
                            string deviceMode, // must be null,
                            int flags,  // use 0
                            ACCESS_MASK accessMask,
                            SECURITY_ATTRIBUTES attributes);
            [DllImport ("user32.dll", SetLastError = true)]
            [return: MarshalAs (UnmanagedType.Bool)]
            internal static extern bool CloseDesktop (IntPtr hDesktop);
    
            [DllImport ("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            [return: MarshalAs (UnmanagedType.Bool)]
            internal static extern bool CreateProcess (string lpApplicationName, string lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes,
                bool bInheritHandles, CreateProcessFlags dwCreationFlags, IntPtr lpEnvironment,
                string lpCurrentDirectory, ref StartupInfo lpStartupInfo, out ProcessInformation lpProcessInformation);
    
            [DllImport ("kernel32.dll", SetLastError = true)]
            [return: MarshalAs (UnmanagedType.Bool)]
            internal static extern bool CloseHandle (IntPtr hObject);
            [DllImport ("kernel32.dll", SetLastError = true)]
            internal static extern UInt32 WaitForSingleObject (IntPtr hHandle, UInt32 dwMilliseconds);
        }
    }
