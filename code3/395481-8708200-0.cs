    public class InteropHelper
    {
        public static void GetReferences(ref Microsoft.Office.Interop.Excel.Application _Application, ref Microsoft.Office.Interop.Excel.Workbook _Workbook)
        {
            EnumChildCallback cb;
            // First, get Excel's main window handle.
            int hwnd = (int)Process.GetCurrentProcess().MainWindowHandle;
            // We need to enumerate the child windows to find one that
            // supports accessibility. To do this, instantiate the
            // delegate and wrap the callback method in it, then call
            // EnumChildWindows, passing the delegate as the 2nd arg.
            if (hwnd != 0)
            {
                int hwndChild = 0;
                cb = new EnumChildCallback(EnumChildProc);
                EnumChildWindows(hwnd, cb, ref hwndChild);
                // If we found an accessible child window, call
                // AccessibleObjectFromWindow, passing the constant
                // OBJID_NATIVEOM (defined in winuser.h) and
                // IID_IDispatch - we want an IDispatch pointer
                // into the native object model.
                if (hwndChild != 0)
                {
                    const uint OBJID_NATIVEOM = 0xFFFFFFF0;
                    Guid IID_IDispatch = new Guid(
                         "{00020400-0000-0000-C000-000000000046}");
                    Microsoft.Office.Interop.Excel.Window ptr = null;
                    int hr = AccessibleObjectFromWindow(
                          hwndChild, OBJID_NATIVEOM, IID_IDispatch.ToByteArray(), ref ptr);
                    if (hr >= 0)
                    {
                        // If we successfully got a native OM
                        // IDispatch pointer, we can QI this for
                        // an Excel Application (using the implicit
                        // cast operator supplied in the PIA).
                        _Application = ptr.Application;
                        _Workbook = _Application.ActiveWorkbook;
                    }
                }
            }
        }
        [DllImport("Oleacc.dll")]
        public static extern int AccessibleObjectFromWindow(
              int hwnd, uint dwObjectID, byte[] riid,
              ref Microsoft.Office.Interop.Excel.Window ptr);
        public delegate bool EnumChildCallback(int hwnd, ref int lParam);
        [DllImport("User32.dll")]
        public static extern bool EnumChildWindows(
              int hWndParent, EnumChildCallback lpEnumFunc,
              ref int lParam);
        [DllImport("User32.dll")]
        public static extern int GetClassName(
              int hWnd, StringBuilder lpClassName, int nMaxCount);
        public static bool EnumChildProc(int hwndChild, ref int lParam)
        {
            StringBuilder buf = new StringBuilder(128);
            GetClassName(hwndChild, buf, 128);
            if (buf.ToString() == "EXCEL7")
            {
                lParam = hwndChild;
                return false;
            }
            return true;
        }
    }
}
