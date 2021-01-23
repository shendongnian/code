    using System;
    using System.Runtime.InteropServices;
    
    namespace BrutalDev.Helpers
    {
      public static class NativeMethods
      {
        // Used to check if the screen saver is running
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemParametersInfo(uint uAction, 
                                                       uint uParam, 
                                                       ref bool lpvParam,
                                                       int fWinIni);
    
        // Used to check if the workstation is locked
        [DllImport("user32", SetLastError = true)]
        private static extern IntPtr OpenDesktop(string lpszDesktop,
                                                 uint dwFlags,
                                                 bool fInherit,
                                                 uint dwDesiredAccess);
        [DllImport("user32", SetLastError = true)]
        private static extern IntPtr OpenInputDesktop(uint dwFlags,
                                                      bool fInherit,
                                                      uint dwDesiredAccess);
    
        [DllImport("user32", SetLastError = true)]
        private static extern IntPtr CloseDesktop(IntPtr hDesktop);
    
        [DllImport("user32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SwitchDesktop(IntPtr hDesktop);
    
        // Check if the workstation has been locked.
        public static bool IsWorkstationLocked()
        {
          const int DESKTOP_SWITCHDESKTOP = 256;
          IntPtr hwnd = OpenInputDesktop(0, false, DESKTOP_SWITCHDESKTOP);
          if (hwnd == IntPtr.Zero)
          {
            // Could not get the input desktop, might be locked already?
            hwnd = OpenDesktop("Default", 0, false, DESKTOP_SWITCHDESKTOP);
          }
    
          // Can we switch the desktop?
          if (hwnd != IntPtr.Zero)
          {
            if (SwitchDesktop(hwnd))
            {
              // Workstation is NOT LOCKED.
              CloseDesktop(hwnd);
            }
            else
            {
              CloseDesktop(hwnd);
              // Workstation is LOCKED.
              return true;
            }
          }
    
          return false;
        }
    
        // Check if the screensaver is busy running.
        public static bool IsScreensaverRunning()
        {
          const int SPI_GETSCREENSAVERRUNNING = 114;
          bool isRunning = false;
    
          if (!SystemParametersInfo(SPI_GETSCREENSAVERRUNNING, 0, ref isRunning, 0))
          {
            // Could not detect screen saver status...
            return false;
          }
    
          if (isRunning)
          {
            // Screen saver is ON.
            return true;
          }
    
          // Screen saver is OFF.
          return false;
        }
      }
    }
