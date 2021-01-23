    [DllImport("user32.dll")]
    private static extern int GetSystemMenu(int hwnd, int revert);
    
    [DllImport("user32.dll")]
    private static extern int GetMenuItemCount(int menu);
    
    [DllImport("user32.dll")]
    private static extern int RemoveMenu(int menu, int position, int flags);
    
    private void DisableCloseButton()
    {
       int menu = GetSystemMenu(Handle.ToInt32(), 0);
       int count = GetMenuItemCount(menu);
       RemoveMenu(menu, count - 1, MF_DISABLED | MF_BYPOSITION);
    }
