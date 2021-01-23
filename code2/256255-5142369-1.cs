            public enum CEDEVICE_POWER_STATE : int
            {
                PwrDeviceUnspecified = -1,
                D0 = 0, // Full On: full power, full functionality
                D1 = 1, // Low Power On: fully functional at low power/performance
                D2 = 2, // Standby: partially powered with automatic wake
                D3 = 3, // Sleep: partially powered with device initiated wake
                D4 = 4, // Off: unpowered
                PwrDeviceMaximum = 5
            }
    
            [DllImport("coredll.dll", SetLastError = true)]
            public static extern int DevicePowerNotify(string name, CEDEVICE_POWER_STATE state, int flags);
    
            [DllImport("coredll.dll", SetLastError = true)]
            public static extern int SetDevicePower(string name, int flags, CEDEVICE_POWER_STATE state);
    
            [DllImport("coredll.dll", SetLastError = true)]
            public static extern int GetDevicePower(string name, int flags, ref CEDEVICE_POWER_STATE state);
