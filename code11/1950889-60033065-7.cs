    //using System;
    //using System.Diagnostics;
    //using System.Drawing;
    //using System.Linq;
    //using System.Runtime.InteropServices;
    //using System.Windows.Forms;
<!---->
    const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
    const int MOUSEEVENTF_RIGHTUP = 0x0010;
    [DllImport("user32.dll")]
    static extern void mouse_event(uint dwFlags, uint dx, uint dy,
        uint cButtons, uint dwExtraInfo);
    [DllImport("user32.dll")]
    static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter,
        string lpszClass, string lpszWindow);
    [StructLayout(LayoutKind.Sequential)]
    struct POINT { public int X; public int Y; }
    [DllImport("user32.dll")]
    static extern bool ClientToScreen(IntPtr hWnd, ref POINT lpPoint);
    public void PerformRightClick(IntPtr hwnd, Point p)
    {
        POINT point = new POINT() { X = p.X, Y = p.Y };
        ClientToScreen(hwnd, ref point);
        Cursor.Position = new Point(point.X, point.Y);
        uint X = (uint)Cursor.Position.X;
        uint Y = (uint)Cursor.Position.Y;
        mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
    }
