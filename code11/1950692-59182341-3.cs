    [DllImport("user32.dll")]
    static extern int TrackPopupMenuEx(IntPtr hmenu, uint fuFlags,
        int x, int y, IntPtr hwnd, IntPtr lptpm);
    [DllImport("user32.dll")]
    static extern bool GetMenuItemRect(IntPtr hWnd, IntPtr hMenu,
        uint uItem, out RECT lprcItem);
    [DllImport("user32.dll")]
    static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT { public int Left, Top, Right, Bottom; }
    const int TPM_RIGHTBUTTON = 0x2;
    const int TPM_RETURNCMD = 0x100;
    const int WM_SYSCOMMAND = 0x112;
    public void ShowSubMenu(MenuItem menuItem, bool asContextMenu = false)
    {
        var mainMenu = menuItem.GetMainMenu();
        var form = mainMenu.GetForm();
        var x = 0; var y = 0;
        if (asContextMenu)
        {
            x = MousePosition.X;
            y = MousePosition.Y;
        }
        else
        {
            GetMenuItemRect(form.Handle, mainMenu.Handle, (uint)menuItem.Index, out RECT rect);
            x = rect.Left;
            y = rect.Bottom;
        }
        var command = TrackPopupMenuEx(menuItem.Handle, TPM_RETURNCMD | TPM_RIGHTBUTTON,
            x, y, form.Handle, IntPtr.Zero);
        if (command > 0)
            SendMessage(form.Handle, WM_SYSCOMMAND, command, IntPtr.Zero);
    }
