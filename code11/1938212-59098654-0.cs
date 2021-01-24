c#
public static class UserInfo
    {
        #region PInvoke
        [DllImport("wtsapi32.dll", SetLastError = true)]
        static extern Int32 WTSEnumerateSessions(
            IntPtr hServer,
            [MarshalAs(UnmanagedType.U4)] Int32 Reserved,
            [MarshalAs(UnmanagedType.U4)] Int32 Version,
            ref IntPtr ppSessionInfo,
            [MarshalAs(UnmanagedType.U4)] ref Int32 pCount);
        [DllImport("wtsapi32.dll")]
        static extern void WTSFreeMemory(IntPtr pMemory);
        [StructLayout(LayoutKind.Sequential)]
        private struct WTS_SESSION_INFO
        {
            public Int32 SessionID;
            [MarshalAs(UnmanagedType.LPStr)]
            public String pWinStationName;
            public WTS_CONNECTSTATE_CLASS State;
        }
        public enum WTS_CONNECTSTATE_CLASS
        {
            WTSActive,
            WTSConnected,
            WTSConnectQuery,
            WTSShadow,
            WTSDisconnected,
            WTSIdle,
            WTSListen,
            WTSReset,
            WTSDown,
            WTSInit
        }
        [DllImport("Wtsapi32.dll")]
        public static extern bool WTSQuerySessionInformation(IntPtr hServer, int sessionId, WTSInfoClass wtsInfoClass, out IntPtr ppBuffer, out uint pBytesReturned);
        public enum WTSInfoClass
        {
            WTSInitialProgram,
            WTSApplicationName,
            WTSWorkingDirectory,
            WTSOEMId,
            WTSSessionId,
            WTSUserName,
            WTSWinStationName,
            WTSDomainName,
            WTSConnectState,
            WTSClientBuildNumber,
            WTSClientName,
            WTSClientDirectory,
            WTSClientProductId,
            WTSClientHardwareId,
            WTSClientAddress,
            WTSClientDisplay,
            WTSClientProtocolType,
            WTSIdleTime,
            WTSLogonTime,
            WTSIncomingBytes,
            WTSOutgoingBytes,
            WTSIncomingFrames,
            WTSOutgoingFrames,
            WTSClientInfo,
            WTSSessionInfo
        }
        [Flags]
        public enum LocalMemoryFlags
        {
            LMEM_FIXED = 0x0000,
            LMEM_MOVEABLE = 0x0002,
            LMEM_NOCOMPACT = 0x0010,
            LMEM_NODISCARD = 0x0020,
            LMEM_ZEROINIT = 0x0040,
            LMEM_MODIFY = 0x0080,
            LMEM_DISCARDABLE = 0x0F00,
            LMEM_VALID_FLAGS = 0x0F72,
            LMEM_INVALID_HANDLE = 0x8000,
            LHND = (LMEM_MOVEABLE | LMEM_ZEROINIT),
            LPTR = (LMEM_FIXED | LMEM_ZEROINIT),
            NONZEROLHND = (LMEM_MOVEABLE),
            NONZEROLPTR = (LMEM_FIXED)
        }
        [DllImport("kernel32.dll")]
        static extern IntPtr LocalAlloc(uint uFlags, UIntPtr uBytes);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LocalFree(IntPtr hMem);
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
        #endregion PInvoke
        #region Helper Methods
        public static bool GetPhysicallyLoggedOnUserName(out string PhysicallyLoggedOnUserName, out string DomainName)
        {
            PhysicallyLoggedOnUserName = string.Empty;
            DomainName = string.Empty;
            IntPtr WTS_CURRENT_SERVER_HANDLE = (IntPtr)null;
            try
            {
                IntPtr ppSessionInfo = IntPtr.Zero;
                Int32 pCount = 0;
                Int32 retval = WTSEnumerateSessions(WTS_CURRENT_SERVER_HANDLE, 0, 1, ref ppSessionInfo, ref pCount);
                Int32 dataSize = Marshal.SizeOf(typeof(WTS_SESSION_INFO));
                if (retval != 0)
                {
                    Int64 current = (int)ppSessionInfo;
                    int totalactiveuser = 0;
                    for (int i = 0; i < pCount; i++)
                    {
                        WTS_SESSION_INFO wts = (WTS_SESSION_INFO)Marshal.PtrToStructure((IntPtr)current, typeof(WTS_SESSION_INFO));
                        current += dataSize;
                        if (wts.State == WTS_CONNECTSTATE_CLASS.WTSActive)
                        {
                            totalactiveuser++;
                        }
                    }
                    if (totalactiveuser < 1)
                    {
                        return false;
                    }
                    current = (int)ppSessionInfo;
                    for (int i = 0; i < pCount; i++)
                    {
                        WTS_SESSION_INFO wts = (WTS_SESSION_INFO)Marshal.PtrToStructure((IntPtr)current, typeof(WTS_SESSION_INFO));
                        current += dataSize;
                        if (wts.State != WTS_CONNECTSTATE_CLASS.WTSActive)
                        {
                            continue;
                        }
                        IntPtr szUserName = IntPtr.Zero;
                        uint dwLen = 0;
                        bool bStatus = WTSQuerySessionInformation(WTS_CURRENT_SERVER_HANDLE, wts.SessionID, WTSInfoClass.WTSUserName, out szUserName, out dwLen);
                        if (bStatus)
                        {
                            IntPtr szUpn = LocalAlloc((uint)LocalMemoryFlags.LMEM_FIXED, new UIntPtr(unchecked((uint)szUserName.ToInt32())));
                            CopyMemory(szUpn, szUserName, (uint)IntPtr.Size);
                            LocalFree(szUpn);
                        }
                        IntPtr ProtoType = IntPtr.Zero;
                        bStatus = WTSQuerySessionInformation(WTS_CURRENT_SERVER_HANDLE, wts.SessionID, WTSInfoClass.WTSClientProtocolType, out ProtoType, out dwLen);
                        int cpt = Marshal.ReadInt32(ProtoType);
                        WTSFreeMemory(ProtoType);
                        if (cpt == 0)   // WTS_PROTOCOL_TYPE_CONSOLE
                        {
                            PhysicallyLoggedOnUserName = Marshal.PtrToStringAnsi(szUserName);
                            WTSFreeMemory(szUserName);
                            dwLen = 0;
                            IntPtr szDomainName = IntPtr.Zero;
                            bStatus = WTSQuerySessionInformation(WTS_CURRENT_SERVER_HANDLE, wts.SessionID, WTSInfoClass.WTSDomainName, out szDomainName, out dwLen);
                            DomainName = Marshal.PtrToStringAnsi(szDomainName);
                            WTSFreeMemory(szDomainName);
                            return true;
                        }
                        WTSFreeMemory(szUserName);
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion Helper Methods
    }
