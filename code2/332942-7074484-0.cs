        // Changes an attribute of the specified window.          
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
      public static void SetDialogStyle(Window window)
        {
            // We disable the control box functionality for the window
            // i.e. remove the minimize, maximize and close button as 
            // well as the system menu.
            var helper = new WindowInteropHelper(window);
            int style = NativeMethods.GetWindowLong(helper.Handle, NativeMethods.GWL_STYLE);
            style &= ~(NativeMethods.WS_SYSMENU | NativeMethods.WS_MAXIMIZEBOX);
            SetWindowLong(helper.Handle, NativeMethods.GWL_STYLE, style);
        }
 
