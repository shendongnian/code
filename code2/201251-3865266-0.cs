    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 714)]
    public struct DISPLAY_DEVICE
    {
        [FieldOffset(0)]
        public int cb;
        [FieldOffset(4)]
        public char DeviceName;
        [FieldOffset(68)]
        public char DeviceString;
        [FieldOffset(324)]
        public int StateFlags;
        [FieldOffset(328)]
        public char DeviceID;
        [FieldOffset(584)]
        public char DeviceKey;
    }
    [DllImport("User32.dll", SetLastError = true)]
    static extern Boolean EnumDisplayDevices(
            string lpDevice,
            uint iDevNum,
            ref DISPLAY_DEVICE lpDisplayDevice,
            uint dwFlags
    );
    public void DetectDevices()
    {
        var flag = true;
        for (uint i = 0; flag && i < 100; i++)
        {
            var device = new DISPLAY_DEVICE();
            device.cb = Marshal.SizeOf(device);
            flag = EnumDisplayDevices(null, i, ref device, 1);
        }
    }
