    [StructLayout(LayoutKind.Sequential)]
    public struct UserData
    {
        public UInt32 misc;
        [MarshalAs(UnmanagedType.U1)]
        public Boolean IsValid;
        public VirtualPosition RightHand;
        public VirtualPosition LeftHand;
        public VirtualPosition Head;
    }
