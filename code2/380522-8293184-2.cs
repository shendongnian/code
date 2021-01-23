    IntPtr handle = GetForegroundWindow();
    List<string> selected = new List<string>();
    var shell = new Shell32.Shell();
    foreach(SHDocVw.InternetExplorer window in shell.Windows())
    {
        if (window.HWND == (int)handle)
        {
            Shell32.FolderItems items = ((Shell32.IShellFolderViewDual2)window.Document).SelectedItems();
            foreach(Shell32.FolderItem item in items)
            {
                selected.Add(item.Path);
            }
        }
    }
