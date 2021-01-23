        //using System.Management
        public bool IsUsbDeviceConnected(string pid, string vid)
        {
            var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBControllerDevice");
            foreach (var device in searcher.Get())
            {
                var usbDevice = Convert.ToString(device);
                if (usbDevice.Contains(pid) && usbDevice.Contains(vid))
                {
                    return true;
                }
            }
            return false;
        }
