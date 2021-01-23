      // Changes an attribute of the specified window.          
      [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
      public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
      // Retrieves information about the specified window.        
      [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
      public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
      public const int GWL_STYLE = (-16);
      public const int WS_SYSMENU = 0x00080000;
      public const int WS_MAXIMIZEBOX = 0x00010000;
      public static void SetDialogStyle(Form window)
        {
            // We disable the control box functionality for the window
            // i.e. remove the minimize, maximize and close button as 
            // well as the system menu.
            
            int style = GetWindowLong(window.Handle, GWL_STYLE);
            style &= ~(WS_SYSMENU | WS_MAXIMIZEBOX);
            SetWindowLong(window.Handle, GWL_STYLE, style);
        }
