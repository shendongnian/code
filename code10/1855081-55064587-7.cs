    namespace Example
    {
        public class UsbEventRegistration : IDisposable
        {
            private const int DBT_DEVTYP_DEVICEINTERFACE = 5;
            private static readonly s_guidDevInterfaceUsbDevice =
                new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED");
            private readonly IntPtr _windowHandle;
            private IntPtr _notificationHandle = IntPtr.Zero;
            public bool IsRegistered => _notificationHandle != IntPtr.Zero;
            public UsbEventRegistration(IntPtr windowHandle)
            {
                _windowHandle = windowHandle;
            }
            
            public void Register()
            {
                var dbdi = new DEV_BROADCAST_DEVICE_INTERFACE
                {
                    DeviceType = DBT_DEVTYP_DEVICEINTERFACE,
                    Reserved = 0,
                    ClassGuid = s_guidDevInterfaceUsbDevice,
                    Name = 0,
                };
                dbdi.Size = Marshal.SizeOf(dbdi);
                IntPtr buffer = Marshal.AllocHGlobal(dbdi.Size);
                Marshal.StructureToPtr(dbdi, buffer, true);
                _notificationHandle = Win32Native.RegisterDeviceNotification(
                    _windowHandle, 
                    buffer, 
                    0);
            }
            // Call on window unload.
            public void Dispose()
            {
                Win32Native.UnregisterDeviceNotification(_notificationHandle);
            }
        }
    }
