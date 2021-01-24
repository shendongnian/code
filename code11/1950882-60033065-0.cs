    //using System.Diagnostics;
    //using System.Runtime.InteropServices;
    const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
    const int MOUSEEVENTF_RIGHTUP = 0x0010;
    [DllImport("user32.dll")]
    static extern void mouse_event(uint dwFlags, uint dx, uint dy,
        uint cButtons, uint dwExtraInfo);
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
    public void PerformRightClick()
    {
        uint X = (uint)Cursor.Position.X;
        uint Y = (uint)Cursor.Position.Y;
        mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        var notepad = Process.GetProcessesByName("notepad").FirstOrDefault();
        if (notepad != null)
        {
            var edit = FindWindowEx(notepad.MainWindowHandle, IntPtr.Zero, "Edit", null);
            GetWindowRect(edit, out RECT rect);
            Cursor.Position = new System.Drawing.Point(rect.Left + 2, rect.Top + 2);
            PerformRightClick();
        }
    }
