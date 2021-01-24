    //using System.Drawing;
    //using System.Diagnostics;
    //using System.Runtime.InteropServices;
    [DllImport("User32.DLL")]
    private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
    const int WM_RBUTTONDOWN = 0x0204;
    const int WM_RBUTTONUP = 0x0205;
    const int WM_MOUSEMOVE = 0x0200;
    private IntPtr MakeLParam(int x, int y)
    {
        return (IntPtr)((y << 16) | (x & 0xFFFF));
    }
    void PerformRightClick(IntPtr hwnd, Point point)
    {
        SendMessage(hwnd, WM_MOUSEMOVE, IntPtr.Zero, MakeLParam(point.X, point.Y));
        SendMessage(hwnd, WM_RBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
        SendMessage(hwnd, WM_RBUTTONUP, IntPtr.Zero, IntPtr.Zero);
    }
    [DllImport("user32.dll")]
    static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter,
        string lpszClass, string lpszWindow);
    [DllImport("user32.dll")]
    static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
    [StructLayout(LayoutKind.Sequential)]
    struct RECT
    {
        public int Left; public int Top;
        public int Right; public int Bottom;
    }
<!---->
    private void button1_Click(object sender, EventArgs e)
    {
        var notepad = Process.GetProcessesByName("notepad").FirstOrDefault();
        if (notepad != null)
        {
            var edit = FindWindowEx(notepad.MainWindowHandle, IntPtr.Zero, "Edit", null);
            GetWindowRect(edit, out RECT rect);
            //Cursor.Position = new System.Drawing.Point(rect.Left + 2, rect.Top + 2);
            PerformRightClick(edit, new Point(rect.Left + 20, rect.Top + 20));
        }
    }
