        //BTHUSB will identify physical bluetooth adapters only, if you want all bluetooth devices use 'WHERE PNPClass='Bluetooth' or specific device 'WHERE Name='Intel(R) Wireless Bluetooth(R)'
        ManagementObjectCollection PhysicalBluetoothAdapterResults = new ManagementObjectSearcher("root\\CIMV2", "SELECT DeviceID FROM Win32_PnPEntity WHERE Service='BTHUSB'").Get();
        foreach(ManagementObject PhysicalBluetoothAdapter in PhysicalBluetoothAdapterResults)
        {
            string DeviceID = PhysicalBluetoothAdapter.Properties["DeviceID"].Value.ToString().Replace("\\","\\\\");
            ManagementObjectCollection AdapterPowerOptionResults = new ManagementObjectSearcher("root\\WMI", $"SELECT * FROM MSPower_DeviceEnable WHERE InstanceName LIKE '{DeviceID}_%'").Get();
            foreach(ManagementObject AdapterPowerOption in AdapterPowerOptionResults)
            {
                AdapterPowerOption.Properties["enable"].Value = false;
                AdapterPowerOption.Put();
            }
        }
