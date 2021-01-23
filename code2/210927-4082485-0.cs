    [StructLayout(LayoutKind.Sequential,
    Pack = 1, CharSet = CharSet.Unicode)]
    public struct DISPLAY_DEVICE
    {
        public int cb;
        [MarshalAs(
        	UnmanagedType.ByValArray,
        	SizeConst=32)]
        	public char[] DeviceName;
        [MarshalAs(
        	UnmanagedType.ByValArray,
        	SizeConst=128)]
        	public char[] DeviceString;
        public int StateFlags;
        [MarshalAs(
        	UnmanagedType.ByValArray,
        	SizeConst = 128)]
        	public char[] DeviceID;
        [MarshalAs(
        	UnmanagedType.ByValArray,
        	SizeConst = 128)]
        	public char[] DeviceKey;
    }
