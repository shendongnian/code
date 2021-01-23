    //using System.Management
    var USBDevices = new ManagementObjectSearcher(@"Select * From Win32_USBControllerDevice");
    foreach (var device in USBDevices.Get())
    {
        foreach (var prop in device.Properties)
        {
            Console.WriteLine(prop.Name + " : " + prop.Value);
        }
    }
