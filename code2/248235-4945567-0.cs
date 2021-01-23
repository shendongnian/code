    ...
    public struct AdminDataM0
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FIELD_SIZE_MSGID + 1)]
        public string MsgId;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FIELD_SIZE_TIME + 1)]
        public string SendTime;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = FIELD_SIZE_TIME + 1)]
        public string ReceiptTime;
    }
    ...
