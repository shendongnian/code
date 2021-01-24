        using System.Management;  
      
        private static void GetUSBDevices()
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE (PNPClass = 'Image' OR PNPClass = 'Camera')");
            foreach (var device in searcher.Get())
            {
                Console.WriteLine($"Device: {device["PNPClass"]} / {device["Caption"]}");
            }
        }
