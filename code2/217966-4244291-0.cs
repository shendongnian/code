    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FT_USB_UNIQID
    {
        public ushort idVendor; 
        public ushort idProduct;
		public ushort bcdDevice;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szSerialNumber;
     }
