        [StructLayout(LayoutKind.Sequential)]
        public struct LoginMessage
        {
            public int msgSize;
            public int msgId;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string szUser;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string szPass;
        }
