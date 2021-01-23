    static IntPtr _taskBar;
    static IntPtr _sipButton;
    public enum Notify_Events {
      NOTIFICATION_EVENT_NONE = 0,
      NOTIFICATION_EVENT_TIME_CHANGE = 1,
      NOTIFICATION_EVENT_SYNC_END = 2,
      NOTIFICATION_EVENT_DEVICE_CHANGE = 7,
      NOTIFICATION_EVENT_RS232_DETECTED = 9,
      NOTIFICATION_EVENT_RESTORE_END = 10,
      NOTIFICATION_EVENT_WAKEUP = 11,
      NOTIFICATION_EVENT_TZ_CHANGE = 12,
      NOTIFICATION_EVENT_OFF_AC_POWER,
      NOTIFICATION_EVENT_ON_AC_POWER
    }
    public enum WindowPosition {
      SWP_HIDEWINDOW = 0x0080,
      SWP_SHOWWINDOW = 0x0040
    }
    [DllImport("coredll.dll", EntryPoint = "FindWindowW", SetLastError = true)]
    public static extern IntPtr FindWindowCE(string lpClassName, string lpWindowName);
    [DllImport("coredll.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
    static void ShowWindowsMenu(bool enable) {
      try {
        if (enable) {
          if (_taskBar != IntPtr.Zero) {
            SetWindowPos(_taskBar, IntPtr.Zero, 0, 0, 240, 26, (int)WindowPosition.SWP_SHOWWINDOW); // display the start bar
          }
        } else {
          _taskBar = FindWindowCE("HHTaskBar", null); // Find the handle to the Start Bar
          if (_taskBar != IntPtr.Zero) { // If the handle is found then hide the start bar
            SetWindowPos(_taskBar, IntPtr.Zero, 0, 0, 0, 0, (int)WindowPosition.SWP_HIDEWINDOW); // Hide the start bar
          }
        }
      } catch (Exception err) {
        ErrorWrapper(enable ? "Show Start" : "Hide Start", err);
      }
      try {
        if (enable) {
          if (_sipButton != IntPtr.Zero) { // If the handle is found then hide the start bar
            SetWindowPos(_sipButton, IntPtr.Zero, 0, 0, 240, 26, (int)WindowPosition.SWP_SHOWWINDOW); // display the start bar
          }
        } else {
          _sipButton = FindWindowCE("MS_SIPBUTTON", "MS_SIPBUTTON");
          if (_sipButton != IntPtr.Zero) { // If the handle is found then hide the start bar
            SetWindowPos(_sipButton, IntPtr.Zero, 0, 0, 0, 0, (int)WindowPosition.SWP_HIDEWINDOW); // Hide the start bar
          }
        }
      } catch (Exception err) {
        ErrorWrapper(enable ? "Show SIP" : "Hide SIP", err);
      }
    }
    static void ErrorWrapper(string routine, Exception e) {
      if (!String.IsNullOrEmpty(e.Message)) {
        MessageBox.Show(e.Message, routine, MessageBoxButtons.OKCancel, MessageBoxIcon.None, 0);
      }
    }
