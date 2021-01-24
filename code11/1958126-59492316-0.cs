    [DllImport(@"C:\Program Files (x86)\Windows Kits\10\Redist\offreg\x64\offreg.dll", EntryPoint = "OREnumKey", CharSet = CharSet.Unicode)]
    public static extern int OREnumKey(IntPtr Handle,
                                        int dwIndex,
                                        IntPtr lpName,
                                        ref int lpcName,
                                        IntPtr lpClass,
                                        ref int lpcClass,
                                        out long lpftLastWriteTime);
    [DllImport(@"C:\Program Files (x86)\Windows Kits\10\Redist\offreg\x64\offreg.dll", CharSet = CharSet.Unicode)]
    public static extern int ORQueryInfoKey(
                                IntPtr Handle,
                                IntPtr lpClass,
                                ref int lpcClass,
                                out int lpcSubKeys,
                                out int lpcMaxSubKeyLen,
                                out int lpcMaxClassLen,
                                out int lpcValues,
                                out int lpcMaxValueNameLen,
                                out int lpcMaxValueLen,
                                out int lpcbSecurityDescriptor,
                                out long lpftLastWriteTime);
    static void Main()
    {
        const int ERROR_MORE_DATA = 234;
        const int ERROR_NO_MORE_ITEMS = 259;
        var res = OROpenHive(@"c:\TEMP\NTUSER.DAT", out var h);
        if (res != 0)
            throw new Win32Exception(res);
        try
        {
            var clsLen = 0;
            var clsPtr = IntPtr.Zero;
            res = ORQueryInfoKey(h, IntPtr.Zero, ref clsLen, out var subKeys, out var maxSubKeyLen, out var maxClassLen, out var values, out var maxValueNameLen, out var maxValueLen, out var securityDescriptor, out var lastWriteTime);
            if (res == ERROR_MORE_DATA)
            {
                clsPtr = Marshal.AllocHGlobal(clsLen);
                try
                {
                    res = ORQueryInfoKey(h, clsPtr, ref clsLen, out subKeys, out maxSubKeyLen, out maxClassLen, out values, out maxValueNameLen, out maxValueLen, out securityDescriptor, out lastWriteTime);
                    if (res == 0)
                    {
                        var cls = Marshal.PtrToStringUni(clsPtr);
                        Console.WriteLine("Class: " + cls);
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(clsPtr);
                }
            }
            if (res != 0)
                throw new Win32Exception(res);
            var nameLen = 0;
            clsLen = 0;
            var i = 0;
            var namePtr = IntPtr.Zero;
            do
            {
                clsLen = 0;
                nameLen = 0;
                res = OREnumKey(h, i, IntPtr.Zero, ref nameLen, IntPtr.Zero, ref clsLen, out lastWriteTime);
                if (res == ERROR_NO_MORE_ITEMS)
                    break;
                if (res == ERROR_MORE_DATA)
                {
                    if (nameLen > 0)
                    {
                        namePtr = Marshal.AllocHGlobal(nameLen);
                    }
                    if (clsLen > 0)
                    {
                        clsPtr = Marshal.AllocHGlobal(clsLen);
                    }
                    try
                    {
                        res = OREnumKey(h, i, namePtr, ref nameLen, clsPtr, ref clsLen, out lastWriteTime);
                        if (res == 0)
                        {
                            Console.WriteLine("LastWriteTime: " + DateTime.FromFileTime(lastWriteTime));
                            if (namePtr != IntPtr.Zero)
                            {
                                var name = Marshal.PtrToStringUni(namePtr);
                                Console.WriteLine("Name: " + name);
                            }
                            if (clsPtr != IntPtr.Zero)
                            {
                                var cls = Marshal.PtrToStringUni(clsPtr);
                                Console.WriteLine("Class: " + cls);
                            }
                        }
                    }
                    finally
                    {
                        if (namePtr != IntPtr.Zero)
                        {
                            Marshal.FreeHGlobal(namePtr);
                            namePtr = IntPtr.Zero;
                        }
                        if (clsPtr != IntPtr.Zero)
                        {
                            Marshal.FreeHGlobal(clsPtr);
                            clsPtr = IntPtr.Zero;
                        }
                    }
                }
                if (res != 0)
                    throw new Win32Exception(res);
                i++;
            }
            while (true);
        }
        finally
        {
            ORCloseHive(h);
        }
    }
