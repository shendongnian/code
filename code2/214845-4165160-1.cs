    IntPtr sysMenuHandle = GetSystemMenu(this.Handle, false);
    //It would be better to find the position at run time of the 'Close' item, but...
    
    InsertMenu(sysMenuHandle, 5, MF_BYPOSITION | MF_SEPARATOR, 0, string.Empty);
    InsertMenu(sysMenuHandle, 6, MF_BYPOSITION , IDM_CUSTOMITEM1, "Item 1");
    InsertMenu(sysMenuHandle, 7, MF_BYPOSITION , IDM_CUSTOMITEM2, "Item 2");
    public const Int32 WM_SYSCOMMAND = 0x112;
    public const Int32 MF_SEPARATOR = 0x800;
    public const Int32 MF_BYPOSITION = 0x400;
    public const Int32 MF_STRING = 0x0;
    public const Int32 IDM_CUSTOMITEM1  = 1000;
    public const Int32 IDM_CUSTOMITEM2 = 1001;
