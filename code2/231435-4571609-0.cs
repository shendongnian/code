      static public class WndInfo
      {
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    
        ...
        public static bool IsWindowTopMost(IntPtr Handle)
        {
          return (GetWindowLong(Handle, GWL_EXSTYLE) & WS_EX_TOPMOST) != 0;
        }
        ...
      }
