    public static class PrinterIcons
    {
        public static Dictionary<string, Icon> GetPrintersWithIcons(IntPtr hwndOwner)
        {
            Dictionary<string, Icon> result = new Dictionary<string, Icon>();
            Shell32.IShellFolder iDesktopFolder = Shell32.GetDesktopFolder();
            try
            {
                IntPtr pidlPrintersFolder;
                if (Shell32.SHGetFolderLocation(hwndOwner, (int)Shell32.CSIDL.CSIDL_PRINTERS, IntPtr.Zero, 0, out pidlPrintersFolder) == 0)
                    try
                    {
                        StringBuilder strDisplay = new StringBuilder(260);
                        Guid guidIShellFolder = Shell32.IID_IShellFolder;
                        IntPtr ptrPrintersShellFolder;
                        iDesktopFolder.BindToObject(pidlPrintersFolder, IntPtr.Zero, ref guidIShellFolder, out ptrPrintersShellFolder);
                        Object objPrintersShellFolder = Marshal.GetTypedObjectForIUnknown(ptrPrintersShellFolder, Shell32.ShellFolderType);
                        try
                        {
                            Shell32.IShellFolder printersShellFolder = (Shell32.IShellFolder)objPrintersShellFolder;
                            IntPtr ptrObjectsList;
                            printersShellFolder.EnumObjects(hwndOwner, Shell32.ESHCONTF.SHCONTF_NONFOLDERS, out ptrObjectsList);
                            Object objEnumIDList = Marshal.GetTypedObjectForIUnknown(ptrObjectsList, Shell32.EnumIDListType);
                            try
                            {
                                Shell32.IEnumIDList iEnumIDList = (Shell32.IEnumIDList)objEnumIDList;
                                IntPtr[] rgelt = new IntPtr[1];
                                IntPtr pidlPrinter;
                                int pceltFetched;
                                Shell32.STRRET ptrString;
                                while (iEnumIDList.Next(1, rgelt, out pceltFetched) == 0 && pceltFetched == 1)
                                {
                                    printersShellFolder.GetDisplayNameOf(rgelt[0],
                                        Shell32.ESHGDN.SHGDN_NORMAL, out ptrString);
                                    if (Shell32.StrRetToBuf(ref ptrString, rgelt[0], strDisplay,
                                        (uint)strDisplay.Capacity) == 0)
                                    {
                                        pidlPrinter = Shell32.ILCombine(pidlPrintersFolder, rgelt[0]);
                                        string printerDisplayNameInPrintersFolder = strDisplay.ToString();
                                        Shell32.SHFILEINFO shinfo = new Shell32.SHFILEINFO();
                                        Shell32.SHGetFileInfo(pidlPrinter, 0, out shinfo, (uint)Marshal.SizeOf(shinfo), Shell32.SHGFI.PIDL | Shell32.SHGFI.AddOverlays | Shell32.SHGFI.Icon);
                                        Icon printerIcon = (Icon)Icon.FromHandle(shinfo.hIcon).Clone();
                                        Shell32.DestroyIcon(shinfo.hIcon);
                                        result.Add(printerDisplayNameInPrintersFolder, printerIcon);
                                    }
                                }
                            }
                            finally
                            {
                                Marshal.ReleaseComObject(objEnumIDList);
                            }
                        }
                        finally
                        {
                            Marshal.ReleaseComObject(objPrintersShellFolder);
                        }
                    }
                    finally
                    {
                        Shell32.ILFree(pidlPrintersFolder);
                    }
            }
            finally
            {
                Marshal.ReleaseComObject(iDesktopFolder);
            }
            return result;
        }
    }
