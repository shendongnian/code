        /// <summary>
        /// Gets the percent of power remaining in the battery.
        /// </summary>
        /// <returns></returns>
        public static double GetBatteryPercent()
        {
            ManagementClass wmi = new ManagementClass("Win32_Battery");
            ManagementObjectCollection allBatteries = wmi.GetInstances();
            double batteryLevel = 0;
            foreach (var battery in allBatteries)
            {
                batteryLevel = Convert.ToDouble(battery["EstimatedChargeRemaining"]);
            }
            return batteryLevel;
        }
