    foreach (Device devicePrimary in MyProject1.Devices)
    {
        var deviceFound = false
        foreach (Device deviceSecondary in MyProject2.Devices)
        {
            Prim = devicePrimary.DeviceItems[1].ToString();
            Sec = deviceSecondary.DeviceItems[1].ToString();
    
            if (Prim == Sec && Prim != null && Sec != null)
            {
                var leftDevice =devicePrimary.DeviceItems[1] 
                                    .GetService<SoftwareContainer() 
                                    .Software as PlcSoftware;
    
                var rightDevice = deviceSecondary.DeviceItems[1] 
                                    .GetService<SoftwareContainer>()                                      
                                    .Software as PlcSoftware;
    
                var Res = leftDevice.CompareTo(rightDevice);
    
                WriteResult(Res.RootElement, "");
            }
            if( Prim == Sec)
            {
                deviceFound = true;
            }
        }
    
        if(deviceFound)
        {
            textBox1.Text = "Device does not exist in both projects.";
            deviceFound = false;
        }
    }
