    class USBDeviceInfo
    {
        public USBDeviceInfo(string deviceId, string name, string description)
        {
            DeviceId = deviceId;
            Name = name;
            Description = description;
        }
        public string DeviceId { get; }
        public string Name { get; }
        public string Description { get; }
        public override string ToString()
        {
            return Name;
        }
    }
    public class Program
    {
        static List<USBDeviceInfo> GetUSBDevices()
        {
            var devices = new List<USBDeviceInfo>();
            using (var mos = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity"))
            {
                using (ManagementObjectCollection collection = mos.Get())
                {
                    foreach (var device in collection)
                    {
                        var id = device.GetPropertyValue("DeviceId").ToString();
                        if (!id.StartsWith("USB", StringComparison.OrdinalIgnoreCase)) 
                            continue;
                        var name = device.GetPropertyValue("Name").ToString();
                        var description = device.GetPropertyValue("Description").ToString();
                        devices.Add(new USBDeviceInfo(id, name, description));
                    }
                }
            }
            return devices;
        }
        private static void Main()
        {
            GetUSBDevices().ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
