    //using System;
    //using System.Diagnostics;
    //using System.Drawing;
    //using System.Linq;
    //using System.Runtime.InteropServices;
    //using System.Windows.Forms;
<!---->
    const int WM_RBUTTONDOWN = 0x0204;
    const int WM_RBUTTONUP = 0x0205;
    const int WM_MOUSEMOVE = 0x0200;
    [DllImport("User32.DLL")]
    static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
    IntPtr MakeLParam(int x, int y) => (IntPtr)((y << 16) | (x & 0xFFFF));
    [DllImport("user32.dll")]
    static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter,
        string lpszClass, string lpszWindow);
    void PerformRightClick(IntPtr hwnd, Point point)
    {
        var pointPtr = MakeLParam(point.X, point.Y);
        SendMessage(hwnd, WM_MOUSEMOVE, IntPtr.Zero, pointPtr);
        SendMessage(hwnd, WM_RBUTTONDOWN, IntPtr.Zero, pointPtr);
        SendMessage(hwnd, WM_RBUTTONUP, IntPtr.Zero, pointPtr);
    }
