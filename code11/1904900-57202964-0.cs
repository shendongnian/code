    foreach (Device devicePrimary in MyProject1.Devices)
    {
        var match = MyProject2.Devices.FirstOrDefault(deviceSecondary => devicePrimary == deviceSecondary);
        if (match != null)
        {
            // found
            var leftDevice =devicePrimary.DeviceItems[1] 
                                .GetService<SoftwareContainer() 
                                .Software as PlcSoftware;
            var rightDevice = deviceSecondary.DeviceItems[1] 
                                .GetService<SoftwareContainer>()                                      
                                .Software as PlcSoftware;
            var Res = leftDevice.CompareTo(rightDevice);
            WriteResult(Res.RootElement, "");
        }
        else
        {
            // not found
            textBox1.Text = "Device does not exist in both projects.";
        }
    }
