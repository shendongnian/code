    namespace Example
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct DEV_BROADCAST_DEVICE_INTERFACE
        {
            public int Size;
            public int DeviceType;
            public int Reserved;
            public Guid ClassGuid;
            public short Name;
        }
        public class Win32Native
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr RegisterDeviceNotification(
                IntPtr hRecipient,
                IntPtr notificationFilter,
                uint flags);
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern uint UnregisterDeviceNotification(IntPtr hHandle);
        }
    }
