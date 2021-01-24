    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;
    
    namespace crs.Includes
    {
        public class ConsoleWindow
        {
            #region Constants
            private const UInt32 GENERIC_WRITE = 0x40000000;
            private const UInt32 GENERIC_READ = 0x80000000;
            private const UInt32 FILE_SHARE_READ = 0x00000001;
            private const UInt32 FILE_SHARE_WRITE = 0x00000002;
            private const UInt32 OPEN_EXISTING = 0x00000003;
            private const UInt32 FILE_ATTRIBUTE_NORMAL = 0x80;
            #endregion
    
            #region WinAPI external functions
            [DllImport("kernel32.dll")]
            private static extern IntPtr GetConsoleWindow();
    
            [DllImport(
                "kernel32.dll",
                SetLastError = true
                )]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool FreeConsole();
    
            [DllImport(
                "kernel32.dll",
                SetLastError = true
                )]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool AllocConsole();
    
            [DllImport(
                "kernel32.dll",
                EntryPoint = "CreateFileW",
                SetLastError = true,
                CharSet = CharSet.Auto,
                CallingConvention = CallingConvention.StdCall
                )]
            private static extern IntPtr CreateFileW(
                string lpFileName,
                UInt32 dwDesiredAccess,
                UInt32 dwShareMode,
                IntPtr lpSecurityAttributes,
                UInt32 dwCreationDisposition,
                UInt32 dwFlagsAndAttributes,
                IntPtr hTemplateFil
                );
            #endregion
    
            #region Public class methods
            public static bool Exists()
            {
                if (GetConsoleWindow() == IntPtr.Zero)
                    return false;
                else
                    return true;
            }
    
            public static bool Create()
            {
                try
                {
                    if (!AllocConsole())
                        throw new Exception("Error!  Could not get a lock on a console window and could not create one.");
    
                    InitializeOutStream();
                    InitializeInStream();
    
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
    
                return false;
            }
            #endregion
    
            #region Functions
            private static void InitializeOutStream()
            {
                FileStream fs = CreateFileStream("CONOUT$", GENERIC_WRITE, FILE_SHARE_WRITE, FileAccess.Write);
                if (fs != null)
                {
                    StreamWriter writer = new StreamWriter(fs) { AutoFlush = true };
                    Console.SetOut(writer);
                    Console.SetError(writer);
                }
            }
    
            private static void InitializeInStream()
            {
                FileStream fs = CreateFileStream("CONIN$", GENERIC_READ, FILE_SHARE_READ, FileAccess.Read);
                if (fs != null)
                    Console.SetIn(new StreamReader(fs));
            }
    
            private static FileStream CreateFileStream(string name, uint win32DesiredAccess, uint win32ShareMode, FileAccess dotNetFileAccess)
            {
                SafeFileHandle file = new SafeFileHandle(CreateFileW(name, win32DesiredAccess, win32ShareMode, IntPtr.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero), true);
                if (!file.IsInvalid)
                {
                    FileStream fs = new FileStream(file, dotNetFileAccess);
                    return fs;
                }
                return null;
            }
            #endregion
        }
    }
