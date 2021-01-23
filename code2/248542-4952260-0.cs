        private static IntPtr hWndConsole = IntPtr.Zero;
        private static IntPtr hWndMenu = IntPtr.Zero;
        public static void Main(string[] args)
        {
            hWndConsole = WinForms.GetConsoleWindow();
            if (hWndConsole != IntPtr.Zero)
            {
                hWndMenu = WinForms.GetSystemMenu(hWndConsole, false);
                if (hWndMenu != IntPtr.Zero)
                {
                    WinForms.EnableMenuItem(hWndMenu, NativeConstants.SC_CLOSE, (uint)(NativeConstants.MF_GRAYED));
                }
            }
        }
