    public static class DFS
    {
        #region Import
        [DllImport("Netapi32.dll", EntryPoint = "NetApiBufferFree")]
        public static extern uint NetApiBufferFree(IntPtr Buffer);
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int NetDfsGetInfo(
            [MarshalAs(UnmanagedType.LPWStr)] string EntryPath,
            [MarshalAs(UnmanagedType.LPWStr)] string ServerName,
            [MarshalAs(UnmanagedType.LPWStr)] string ShareName,
            int Level,
            out IntPtr Buffer);
        [DllImport("Netapi32.dll")]
        public static extern int NetDfsGetClientInfo(
            [MarshalAs(UnmanagedType.LPWStr)] string EntryPath,
            [MarshalAs(UnmanagedType.LPWStr)] string ServerName,
            [MarshalAs(UnmanagedType.LPWStr)] string ShareName,
            int Level,
            out IntPtr Buffer);
        #endregion
        #region Structures
        public struct DFS_INFO_3
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string EntryPath;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string Comment;
            public UInt32 State;
            public UInt32 NumberOfStorages;
            public IntPtr Storages;
        }
        public struct DFS_STORAGE_INFO
        {
            public Int32 State;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string ServerName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string ShareName;
        }
        #endregion
        const int DFS_VOLUME_STATE_OK = 0x00000001;
        const int DFS_VOLUME_STATE_ONLINE = 0x00000004;
        const int DFS_STORAGE_STATE_ONLINE = 0x00000002;
        const int DFS_STORAGE_STATE_ACTIVE = 0x00000004;
        public static String GetSharePath(String DFSPath)
        {
            if (!String.IsNullOrEmpty(DFSPath))
            {
                IntPtr Buffer = IntPtr.Zero;
                try
                {
                    int Error = NetDfsGetClientInfo(DFSPath, null, null, 3, out Buffer);
                    if (Error == 0)
                    {
                        DFS_INFO_3 DFSInfo = (DFS_INFO_3)Marshal.PtrToStructure(Buffer, typeof(DFS_INFO_3));
                        if ((DFSInfo.State & DFS_VOLUME_STATE_OK) > 0)
                        {
                            String SubPath = DFSPath.Remove(0, 1 + DFSInfo.EntryPath.Length).TrimStart(new Char[] { '\\' });
                            for (int i = 0; i < DFSInfo.NumberOfStorages; i++)
                            {
                                IntPtr Storage = new IntPtr(DFSInfo.Storages.ToInt64() + i * Marshal.SizeOf(typeof(DFS_STORAGE_INFO)));
                                DFS_STORAGE_INFO StorageInfo = (DFS_STORAGE_INFO)Marshal.PtrToStructure(Storage, typeof(DFS_STORAGE_INFO));
                                if ((StorageInfo.State & DFS_STORAGE_STATE_ACTIVE) > 0)
                                {
                                    if (String.IsNullOrEmpty(SubPath))
                                    {
                                        return String.Format(@"\\{0}\{1}", StorageInfo.ServerName, StorageInfo.ShareName);
                                    }
                                    else
                                    {
                                        return GetSharePath(String.Format(@"\\{0}\{1}\{2}", StorageInfo.ServerName, StorageInfo.ShareName, SubPath));
                                    }
                                }
                            }
                        }
                    }
                    else if (Error == 2662)
                        return DFSPath;
                }
                finally
                {
                    NetApiBufferFree(Buffer);
                }
            }
            return null;
        }
        public static String GetShareName(String SharePath)
        {
            if (!String.IsNullOrEmpty(SharePath))
            {
                String[] Tokens = SharePath.Trim(new Char[] { '\\' }).Split(new Char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                if (2 <= Tokens.Length)
                    return Tokens[1];
            }
            return null;
        }
    }
