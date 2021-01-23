    public enum DesktopWindow
    {
        ProgMan,
        SHELLDLL_DefViewParent,
        SHELLDLL_DefView,
        SysListView32
    }
    
    public static IntPtr GetDesktopWindow(DesktopWindow desktopWindow)
    {
        IntPtr _ProgMan = GetShellWindow();
        IntPtr _SHELLDLL_DefViewParent = _ProgMan;
        IntPtr _SHELLDLL_DefView = FindWindowEx(_ProgMan, IntPtr.Zero, "SHELLDLL_DefView", null);
        IntPtr _SysListView32 = FindWindowEx(_SHELLDLL_DefView, IntPtr.Zero, "SysListView32", "FolderView");
    
        if (_SHELLDLL_DefView == IntPtr.Zero)
        {
            EnumWindows((hwnd, lParam) =>
            {
                if (GetClassName(hwnd) == "WorkerW")
                {
                    IntPtr child = FindWindowEx(hwnd, IntPtr.Zero, "SHELLDLL_DefView", null);
                    if (child != IntPtr.Zero)
                    {
                        _SHELLDLL_DefViewParent = hwnd;
                        _SHELLDLL_DefView = child;
                        _SysListView32 = FindWindowEx(child, IntPtr.Zero, "SysListView32", "FolderView"); ;
                        return false;
                    }
                }
                return true;
            }, IntPtr.Zero);
        }
    
        switch (desktopWindow)
        {
            case DesktopWindow.ProgMan:
                return _ProgMan;
            case DesktopWindow.SHELLDLL_DefViewParent:
                return _SHELLDLL_DefViewParent;
            case DesktopWindow.SHELLDLL_DefView:
                return _SHELLDLL_DefView;
            case DesktopWindow.SysListView32:
                return _SysListView32;
            default:
                return IntPtr.Zero;
        }
    }
