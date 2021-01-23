    //using System.Management
    public bool IsUsbDeviceConnected(string pid, string vid)
    {   
      using (var searcher = 
        new ManagementObjectSearcher(@"Select * From Win32_USBControllerDevice"))
      {
        using (var collection = searcher.Get())
        {
          foreach (var device in collection)
          {
            var usbDevice = Convert.ToString(device);
            if (usbDevice.Contains(pid) && usbDevice.Contains(vid))
              return true;
          }
        }
      }
      return false;
    }
