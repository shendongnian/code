        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll")]
        private static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        [DllImport("user32.dll")]
        private static extern bool
        GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
        private struct POINTAPI
        {
            public int x;
            public int y;
        }
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public POINTAPI ptMinPosition;
            public POINTAPI ptMaxPosition;
            public RECT rcNormalPosition;
        }
        public string FullscreenProcess()
        {
            IntPtr foreWindow = GetForegroundWindow();
            // get the placement
            WINDOWPLACEMENT forePlacement = new WINDOWPLACEMENT();
            forePlacement.length = Marshal.SizeOf(forePlacement);
            GetWindowPlacement(foreWindow, ref forePlacement);
            
            if (forePlacement.rcNormalPosition.top == 0 && forePlacement.rcNormalPosition.left == 0 && forePlacement.rcNormalPosition.right == Screen.PrimaryScreen.Bounds.Width && forePlacement.rcNormalPosition.bottom == Screen.PrimaryScreen.Bounds.Height)
            {
                uint processID;
                GetWindowThreadProcessId(foreWindow, out processID);
                Process proc = Process.GetProcessById((int)processID);
                return proc.ProcessName;
            }
        return null;
        }
