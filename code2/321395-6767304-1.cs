    //DisplayDevice is a wrapper ... you can find it [here](http://pinvoke.net/default.aspx/Structures/DISPLAY_DEVICE.html)
    List<DisplayDevice> devices = new List<DisplayDevice>();
    bool error = false;
    //Here I am listing all DisplayDevices (Monitors)
    for (int devId = 0; !error; devId++)
    {
        try
        {
            DisplayDevice device = new DisplayDevice();
            device.cb = Marshal.SizeOf(typeof(DisplayDevice));
            error = EnumDisplayDevices(null, devId, ref device, 0) == 0;
            devices.Add(device);
        }
        catch (Exception)
        {
            error = true;
        }
    }
    List<DisplaySet> devicesAndModes = new List<DisplaySet>();
    foreach (var dev in devices)
    {
        error = false;
        //Here I am listing all DeviceModes (Resolutions) for each DisplayDevice (Monitors)
        for (int i = 0; !error; i++)
        {
            try
            {
                //DeviceMode is a wrapper. You can find it [here](http://pinvoke.net/default.aspx/Structures/DEVMODE.html)
                DeviceMode mode = new DeviceMode();
                error = EnumDisplaySettings(dev.DeviceName, -1 + i, ref mode) == 0;
                //Display 
                devicesAndModes.Add(new DisplaySet { DisplayDevice = dev, DeviceMode = mode });
            }
            catch (Exception ex)
            {
                error = true;
            }
        }
    }
    //Select any 800x600 resolution ...
    DeviceMode d800x600 = devicesAndModes.Where(s => s.DeviceMode.dmPelsWidth == 800).First().DeviceMode;
    //Apply the selected resolution ...
    ChangeDisplaySettings(ref d800x600, 0);
