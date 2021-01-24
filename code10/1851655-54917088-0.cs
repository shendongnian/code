        using System.Management;  
      
        private static void GetUSBDevices()
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPSignedDriver Where DeviceClass = 'IMAGE'");
            foreach (var device in searcher.Get())
            {
                Console.WriteLine($"Device: {device["FriendlyName"]}");
            }
        }
