    public static ShellFileGetInfo.ShellFileType GetExeType(string file)
    {
        ShellFileGetInfo.ShellFileType type = ShellFileGetInfo.ShellFileType.FileNotFound;
        if (File.Exists(file))
        {
            ShellFileGetInfo.SHFILEINFO shinfo = new ShellFileGetInfo.SHFILEINFO();
            IntPtr ptr = ShellFileGetInfo.SHGetFileInfo(file, 128, ref shinfo, (uint)Marshal.SizeOf(shinfo), ShellFileGetInfo.SHGFI_EXETYPE);
            int wparam = ptr.ToInt32();
            int loWord = wparam & 0xffff;
            int hiWord = wparam >> 16;
            type = ShellFileGetInfo.ShellFileType.Unknown;
            if(wparam != 0)
            {
                if (hiWord == 0x0000 && loWord == 0x5a4d)
                {
                    type = ShellFileGetInfo.ShellFileType.Dos;
                }
                else if (hiWord == 0x0000 && loWord == 0x4550)
                {
                    type = ShellFileGetInfo.ShellFileType.Console;
                }
                else if ((hiWord != 0x0000) && (loWord == 0x454E || loWord == 0x4550 || loWord == 0x454C))
                {
                    type = ShellFileGetInfo.ShellFileType.Windows;
                }
            }
        }
        return type;
    }
