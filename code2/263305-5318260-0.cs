        public class myClass
        {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
        const UInt32 SW_HIDE =         0;
        const UInt32 SW_SHOWNORMAL =       1;
        const UInt32 SW_NORMAL =       1;
        const UInt32 SW_SHOWMINIMIZED =    2;
        const UInt32 SW_SHOWMAXIMIZED =    3;
        const UInt32 SW_MAXIMIZE =     3;
        const UInt32 SW_SHOWNOACTIVATE =   4;
        const UInt32 SW_SHOW =         5;
        const UInt32 SW_MINIMIZE =     6;
        const UInt32 SW_SHOWMINNOACTIVE =  7;
        const UInt32 SW_SHOWNA =       8;
        const UInt32 SW_RESTORE =      9;
        public myClass()
        {
            var proc = Process.GetProcessesByName("notepad");
            if (proc.Length > 0)
            {
                bool isNotepadMinimized = myClass.GetMinimized(proc[0].MainWindowHandle);
                if (isNotepadMinimized)
                    Console.WriteLine("Notepad is Minimized!");
            }
        }
        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }
        public static bool GetMinimized(IntPtr handle)
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.length = Marshal.SizeOf(placement);
            GetWindowPlacement(handle, ref placement);
            return placement.flags == SW_SHOWMINIMIZED;
        }
    }
