    enum WindowMessages {
        WM_SETCURSOR  = 0x0020,
        WM_MOUSEMOVE  = 0x0200,
        ....
    }
    enum HitTestCodes {
        HTCLIENT = 1,
        ....
    }
    ....
    IntPtr hWnd = [get your window handle some how]
    int lParam = ((int)WindowMessages.WM_MOUSEMOVE) << 16 + (int)HitTestCodes.HTCLIENT;
    SendMessage(hWnd, (uint)WindowMessages.WM_SETCURSOR, hWnd, (IntPtr)lParam);
         
