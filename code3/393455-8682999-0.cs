    public static void SelectItemInExplorer(IntPtr hwnd, string itemPath, bool edit)
    {
        if (itemPath == null)
            throw new ArgumentNullException("itemPath");
        IntPtr folder = PathToAbsolutePIDL(hwnd, Path.GetDirectoryName(itemPath));
        IntPtr file = PathToAbsolutePIDL(hwnd, itemPath);
        try
        {
            SHOpenFolderAndSelectItems(folder, 1, new[] { file }, edit ? 1 : 0);
        }
        finally
        {
            ILFree(folder);
            ILFree(file);
        }
    }
    [DllImport("shell32.dll")]
    private static extern int SHOpenFolderAndSelectItems(IntPtr pidlFolder, uint cidl, IntPtr[] apidl, int dwFlags);
    [DllImport("shell32.dll")]
    private static extern void ILFree(IntPtr pidl);
    [DllImport("shell32.dll")]
    private static extern int SHGetDesktopFolder(out IShellFolder ppshf);
    [DllImport("ole32.dll")]
    private static extern int CreateBindCtx(int reserved, out IBindCtx ppbc);
    [ComImport, Guid("000214E6-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IShellFolder
    {
        void ParseDisplayName(IntPtr hwnd, IBindCtx pbc, [In, MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName, out uint pchEaten, out IntPtr ppidl, ref uint pdwAttributes);
        // NOTE: we declared only what we needed...
    }
    private static IntPtr GetShellFolderChildrenRelativePIDL(IntPtr hwnd, IShellFolder parentFolder, string displayName)
    {
        IBindCtx bindCtx;
        CreateBindCtx(0, out bindCtx);
        uint pchEaten;
        uint pdwAttributes = 0;
        IntPtr ppidl;
        parentFolder.ParseDisplayName(hwnd, bindCtx, displayName, out pchEaten, out ppidl, ref pdwAttributes);
        return ppidl;
    }
    private static IntPtr PathToAbsolutePIDL(IntPtr hwnd, string path)
    {
        IShellFolder desktopFolder;
        SHGetDesktopFolder(out desktopFolder);
        return GetShellFolderChildrenRelativePIDL(hwnd, desktopFolder, path);
    }
