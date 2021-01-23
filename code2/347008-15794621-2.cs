    static partial class NativeMethods
    {
        public static class StartupInfo
        {
            [StructLayout(LayoutKind.Sequential)]
            public class STARTUPINFO
            {
                public readonly UInt32 cb;  
                private IntPtr lpReserved;
                [MarshalAs(UnmanagedType.LPWStr)] public readonly string lpDesktop;
                [MarshalAs(UnmanagedType.LPWStr)] public readonly string lpTitle;
                public readonly UInt32 dwX;
                public readonly UInt32 dwY;
                public readonly UInt32 dwXSize;
                public readonly UInt32 dwYSize;
                public readonly UInt32 dwXCountChars;
                public readonly UInt32 dwYCountChars;
                public readonly UInt32 dwFillAttribute;
                public readonly UInt32 dwFlags;
                [MarshalAs(UnmanagedType.U2)] public readonly UInt16 wShowWindow;
                [MarshalAs(UnmanagedType.U2)] private UInt16 cbReserved2;
                private IntPtr lpReserved2;
                public readonly IntPtr hStdInput;
                public readonly IntPtr hStdOutput;
                public readonly IntPtr hStdError;
            }
            public readonly static STARTUPINFO FromCurrentProcess = null;
            
            const uint STARTF_USESHOWWINDOW = 0x00000001;
            const ushort SW_HIDE = 0;
            const ushort SW_SHOWNORMAL = 1;
            const ushort SW_SHOWMINIMIZED = 2;
            const ushort SW_SHOWMAXIMIZED = 3;
            const ushort SW_MINIMIZE = 6;
            const ushort SW_SHOWMINNOACTIVE = 7;
            const ushort SW_FORCEMINIMIZE = 11;
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            static extern void GetStartupInfoW(IntPtr startupInfoPtr);
            static StartupInfo() //Static constructor
            {
                FromCurrentProcess = new STARTUPINFO();
                int length = Marshal.SizeOf(typeof(STARTUPINFO));
                IntPtr ptr = Marshal.AllocHGlobal(length);
                Marshal.StructureToPtr(FromCurrentProcess, ptr, false);
                
                GetStartupInfoW(ptr);
                
                Marshal.PtrToStructure(ptr, FromCurrentProcess);
                Marshal.FreeHGlobal(ptr);
            }
            public static ProcessWindowStyle GetInitialWindowStyle()
            {
                if ((FromCurrentProcess.dwFlags & STARTF_USESHOWWINDOW) == 0) return ProcessWindowStyle.Normal;
                switch (FromCurrentProcess.wShowWindow)
                {
                    case SW_HIDE: return ProcessWindowStyle.Hidden;
                    case SW_SHOWNORMAL: return ProcessWindowStyle.Normal;
                    case SW_MINIMIZE:
                    case SW_FORCEMINIMIZE:
                    case SW_SHOWMINNOACTIVE:
                    case SW_SHOWMINIMIZED: return ProcessWindowStyle.Minimized;
                    case SW_SHOWMAXIMIZED: return ProcessWindowStyle.Maximized;
                    default: return ProcessWindowStyle.Normal;
                }
            }
        } 
    }
