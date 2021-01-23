    static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();
            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select *      FROM Win32_PnPEntity where Description Like ""%Smart%card%"""))
                collection = searcher.Get();
            string Device_ID = "";
            foreach (var device in collection)
            {
                devices.Add(new USBDeviceInfo(
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("PNPDeviceID"),
                 (string)device.GetPropertyValue("Name"),
                (string)device.GetPropertyValue("Description"),
                (string)device.GetPropertyValue("Status")));
                Device_ID = (string)device.GetPropertyValue("DeviceID");
            }
            collection.Dispose();
            return devices;
        }
