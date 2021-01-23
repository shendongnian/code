    public class WindowWrapper : IWin32Window
    {
      private readonly IntPtr hwnd;
      public IntPtr Handle {
        get { return hwnd; }
      }
      public WindowWrapper(IntPtr handle) {
        hwnd = handle;
      }
    }
