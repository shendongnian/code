    public enum BatteryStatus : ushort
    {
        Discharging = 1,
        AcConnected,
        FullyCharged,
        Low,
        Critical,
        Charging,
        ChargingAndHigh,
        ChargingAndLow,
        ChargingAndCritical,
        Undefined,
        PartiallyCharged
    }
...
        /// <summary>
        /// Gets the battery status.
        /// </summary>
        /// <returns></returns>
        public static BatteryStatus GetBatteryStatus()
        {
            ManagementClass wmi = new ManagementClass("Win32_Battery");
            ManagementObjectCollection allBatteries = wmi.GetInstances();
            BatteryStatus status = BatteryStatus.Undefined;
            foreach (var battery in allBatteries)
            {
                PropertyData pData = battery.Properties["BatteryStatus"];
                if (pData != null && pData.Value != null && Enum.IsDefined(typeof(BatteryStatus), pData.Value))
                {
                    status = (BatteryStatus)pData.Value;
                }
            }
            return status;
        }
